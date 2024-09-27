using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopyEnemyStupid : EnemyMovement
{
    private void Awake()
    {
        _agent = null;
        _spr = GetComponentInChildren<SpriteRenderer>();
        _col = GetComponentInChildren<EnemyCollision>();
        _rb = GetComponent<Rigidbody2D>();
        defaultPainDuration = painDuration;
    }
    private void OnEnable()
    {
        currentState = defaultState;
    }
    private void FixedUpdate()
    {
        switch (currentState)
        {
            case EnemyState.PATROL:
                Patrol();
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
        yield return new WaitForFixedUpdate();
    }
}
