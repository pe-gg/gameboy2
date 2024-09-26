using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MageMovement : EnemyMovement
{
    [SerializeField] private RodProjectile _proj;
    [SerializeField] private float _projectileSpeed;
    private MageAnimation _anim;

    private int _defaultSpeed;

    private bool _attacked;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _spr = GetComponentInChildren<SpriteRenderer>();
        _col = GetComponentInChildren<EnemyCollision>();
        _anim = GetComponentInChildren<MageAnimation>();
        _rb = GetComponent<Rigidbody2D>();
        defaultPainDuration = painDuration;
        _defaultSpeed = (int)_agent.speed;
        _agent.updateRotation = false;
    }
    private void OnDisable()
    {
        StopCoroutine("AttackTimer");
    }
    private void OnEnable()
    {
        currentState = base.defaultState;
        if (defaultState == EnemyState.PATROL)
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
        GetTargetDirection();
        StartCoroutine("AttackTimer");
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(_agent.velocity.normalized);
        switch (currentState)
        {
            case EnemyState.PATROL:
                Patrol();
                return;
            case EnemyState.FOLLOW:
                Attack();
                return;
            case EnemyState.PAIN:
                if (_inPain)
                    return;
                StartPain();
                return;
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, patrolPoints[_currentPoint].transform.position) <= acceptanceRadius)
        {
            _currentPoint = (_currentPoint + 1) % patrolPoints.Length;
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
            GetTargetDirection();
        }
    }

    private void Attack()
    {
        //Debug.Log("attacking");
        if (_attacked)
        {
            _rb.velocity = Vector3.zero;
            _agent.speed = 0.01f;
            _agent.SetDestination(target.transform.position);
            Invoke("FireProjectile", 0.75f); //this is HORRIBLE
            Invoke("SwitchState", 1f);
            _attacked = false;
        }
    }

    private void SwitchState()
    {
        if(currentState == EnemyState.FOLLOW)
        {
            _anim.ToggleAttack();
            //Debug.Log("switching from ATTACK to PATROL");
            StartCoroutine("AttackTimer");
            _agent.speed = _defaultSpeed;
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
            currentState = EnemyState.PATROL;
            return;
        }
        if (currentState == EnemyState.PATROL)
        {
            _anim.ToggleAttack();
            //Debug.Log("switching from PATROL to ATTACK");
            currentState = EnemyState.FOLLOW;
            return;
        }
    }

    private IEnumerator AttackTimer()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(3f);
        if(currentState == EnemyState.PATROL)
            _attacked = true;
        SwitchState();
        StopCoroutine("AttackTimer");
    }

    private void FireProjectile()
    {
        Vector2 dir = target.transform.position - this.transform.position;
        RodProjectile firedProjectile = Instantiate(_proj, this.transform.position, Quaternion.identity);
        firedProjectile.AddForce(_projectileSpeed * dir);
    }

    private void StartPain()
    {
        _inPain = true;
        _inPain2 = true;
        StartCoroutine("Pain");
    }

    IEnumerator Pain()
    {
        while (_inPain2)
        {
            _agent.velocity = _rb.velocity;
            painDuration--;
            if (painDuration <= 0) 
                _inPain2 = false;
            yield return new WaitForFixedUpdate();
        }
        painDuration = defaultPainDuration;
        currentState = EnemyState.PATROL;
        _rb.velocity = Vector2.zero;
        _col.thisCol.enabled = true;
        _inPain = false;
        _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
        yield return new WaitForFixedUpdate();
    }

    private void GetTargetDirection()
    {
        Vector3 direction = (target.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        FacingDirection = angle;
    }
}
