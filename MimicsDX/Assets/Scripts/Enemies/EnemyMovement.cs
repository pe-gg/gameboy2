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
    private Rigidbody2D _rb;
    private int defaultPainDuration;
    private NavMeshAgent _agent;
    private int _currentPoint;
    public EnemyState currentState;
    private SpriteRenderer _spr;
    private EnemyCollision _col;
    private bool _inPain;
    private bool _inPain2;
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
        currentState = EnemyState.FOLLOW;
        defaultPainDuration = painDuration;
    }
    private void FixedUpdate()
    {
        FixRotations();
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

    }

    private void Follow()
    {
        _agent.SetDestination(target.transform.position);
    }

    private void StartPain()
    {
        _inPain = true;
        _inPain2 = true;
        StartCoroutine("Pain");
    }

    IEnumerator Pain()
    {
        Debug.Log("pain");
        while (_inPain2)
        {
            _agent.velocity = _rb.velocity;
            painDuration--;
            if (painDuration <= 0) 
                _inPain2 = false;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("out of pain");
        painDuration = defaultPainDuration;
        currentState = EnemyState.FOLLOW;
        _rb.velocity = Vector2.zero;
        _col.thisCol.enabled = true;
        _inPain = false;
        yield return new WaitForFixedUpdate();
    }

    private void FixRotations()
    {
        _spr.gameObject.transform.rotation = Quaternion.identity;
        _spr.gameObject.transform.position = this.transform.position;
    }
}
