using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyMovement;

public class BossStates : MonoBehaviour
{
    [SerializeField] private GameObject[] _teleportPoints;
    private PlayerController _target;
    private BossState _currentState;

    private enum BossState
    {
        IDLE,
        TELEPORTING,
        ATTACKING,
        VULNERABLE,
        PAIN
    }

    private void Awake()
    {
        _target = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        switch (_currentState)
        {
            case BossState.IDLE:
                Idle();
                return;
            case BossState.TELEPORTING:
                Teleporting();
                return;
            case BossState.ATTACKING:
                Attacking();
                return;
            case BossState.VULNERABLE:
                Vulnerable();
                return;
            case BossState.PAIN:
                Pain();
                return;
        }
    }

    private void Idle()
    {

    }
    private void Teleporting()
    {

    }
    private void Attacking()
    {

    }
    private void Vulnerable()
    {

    }
    private void Pain()
    {

    }
}
