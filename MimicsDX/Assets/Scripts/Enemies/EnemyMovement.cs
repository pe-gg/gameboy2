using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private float acceptanceRadius;
    [SerializeField] private GameObject target;
    [SerializeField] private int painDuration;
    [SerializeField] private EnemyState defaultState;

    private NavMeshAgent _agent;
    private SpriteRenderer _spr;
    private EnemyCollision _col;
    private Rigidbody2D _rb;

    public EnemyState currentState;

    private int defaultPainDuration;
    private int _currentPoint;

    public float FacingDirection;

    private bool _inPain;
    private bool _inPain2;
    public bool playerDetected;
    public enum EnemyState
    {
        PATROL,
        FOLLOW,
        PAIN
    }
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _spr = GetComponentInChildren<SpriteRenderer>();
        _col = GetComponentInChildren<EnemyCollision>();
        _rb = GetComponent<Rigidbody2D>();
        defaultPainDuration = painDuration;
        _agent.updateRotation = false;
    }
    private void OnEnable()
    {
        currentState = defaultState;
        if (defaultState == EnemyState.PATROL)
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
        GetTargetDirection();
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
                Follow();
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
        if (playerDetected)
        {
            currentState = EnemyState.FOLLOW;
            return;
        }
        if (Vector2.Distance(transform.position, patrolPoints[_currentPoint].transform.position) <= acceptanceRadius)
        {
            _currentPoint = (_currentPoint + 1) % patrolPoints.Length;
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
            GetTargetDirection();
        }

    }

    private void Follow()
    {
        if (!playerDetected)
        {
            currentState = EnemyState.PATROL;
            _agent.SetDestination(patrolPoints[_currentPoint].transform.position);
            return;
        }
        _agent.SetDestination(target.transform.position);
        GetTargetDirection();
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
        currentState = EnemyState.FOLLOW;
        _rb.velocity = Vector2.zero;
        _col.thisCol.enabled = true;
        _inPain = false;
        yield return new WaitForFixedUpdate();
    }

    private void GetTargetDirection()
    {
        Vector3 direction = (target.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        FacingDirection = angle;
    }
}
