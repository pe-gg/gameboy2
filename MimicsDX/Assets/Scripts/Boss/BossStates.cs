using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyMovement;

public class BossStates : MonoBehaviour
{
    [SerializeField] private GameObject[] _teleportPoints;
    [SerializeField] private float _idleTime;
    [SerializeField] private RodProjectile[] _proj;
    private Collider2D _col;
    private PlayerController _target;
    public BossState currentState;

    private BossState _changeState;
    private float _timeToWait;

    private int _teleportAmount;

    private bool _idle;
    private bool _teleporting;
    private bool _teleLoop;
    private bool _attacking;
    private bool _vulnerable;
    private bool _pain;

    private bool _inPain;
    private bool _inPain2;
    private int _painDuration = 20;

    private int _hitsTaken;
    public enum BossState
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
        _col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        switch (currentState)
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
        if (_idle)
            return;
        Debug.Log("idle");
        _idle = true;
        SetChangeStateParameters(BossState.ATTACKING, _idleTime);
        StartCoroutine("ChangeState");
    }
    private IEnumerator IdleTimer()
    {
        yield return new WaitForSeconds(_idleTime);
        _idle = false;
        StopCoroutine(IdleTimer());
    }
    private void Teleporting()
    {
        if (_teleporting)
            return;
        Debug.Log("teleporting");
        _teleporting = true;
        Teleport();
    }
    private void Teleport()
    {
        int timer = Random.Range(32, 65);
        _teleportAmount = timer;
        _teleLoop = true;
        StartCoroutine(TeleportLoop(_teleportAmount));
    }
    private IEnumerator TeleportLoop(int timer)
    {
        while (_teleLoop)
        {
            int choose = Random.Range(0, 3);
            this.transform.position = _teleportPoints[choose].transform.position;
            _teleportAmount--;
            if (_teleportAmount <= 0)
                _teleLoop = false;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForFixedUpdate();
        SetChangeStateParameters(BossState.IDLE, 1f);
        StartCoroutine("ChangeState");
        StopCoroutine("TeleportLoop");
    }
    private void Attacking()
    {
        if (_attacking)
            return;
        Debug.Log("attacking");
        _attacking = true;
        FireProjectile();
    }

    private void FireProjectile()
    {
        _col.enabled = false;
        Invoke("ReEnableCollider", 0.5f);
        int choose = Random.Range(0, 2);
        Vector2 dir = _target.transform.position - this.transform.position;
        dir = dir.normalized;
        RodProjectile firedProjectile = Instantiate(_proj[choose], this.transform.position, Quaternion.identity);
        firedProjectile.AddForce(5f * dir);
        SetChangeStateParameters(BossState.TELEPORTING, 3f);
        StartCoroutine("ChangeState");
    }

    private void ReEnableCollider()
    {
        _col.enabled = true;
    }

    private void Vulnerable()
    {
        if (_vulnerable)
            return;
        _vulnerable = true;
        StopCoroutine("ChangeState");
    }
    private void Pain()
    {
        _vulnerable = false;
        if (_pain)
            return;
        _pain = true;
        _hitsTaken++;
        if (_hitsTaken >= 3)
        {
            SetChangeStateParameters(BossState.TELEPORTING, 0.1f);
            StartCoroutine("ChangeState");
            _hitsTaken = 0;
            return;
        }
        StartPain();
    }
    private void StartPain()
    {
        _inPain = true;
        _inPain2 = true;
        StartCoroutine("PainTimer");
    }

    private IEnumerator PainTimer()
    {
        while (_inPain2)
        {
            _painDuration--;
            if (_painDuration <= 0)
                _inPain2 = false;
            yield return new WaitForFixedUpdate();
        }
        _painDuration = 20;
        currentState = BossState.VULNERABLE;
        _col.enabled = true;
        _inPain = false;
        _pain = false;
        yield return new WaitForFixedUpdate();
    }

    private void SetChangeStateParameters(BossState state, float time) //because you cant stop a coroutine that isn't started via a string call
    {
        _changeState = state;
        _timeToWait = time;
    }

    private IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(_timeToWait);
        currentState = _changeState;
        _idle = false; //this is obscenely gross but i could not for the life of me figure out how to pass through a boolean object reference rather than a boolean's true/false state
        _teleporting = false; //wanted to try instead to put them all in an array, that way i could just pass through the int of their index and turn them off in a single line
        _attacking = false; //however, doing that is apparently evil and taboo and there's no resources online for it
        _vulnerable = false; //so the tl;dr here is my c# fundamentals continue to be abysmal and that is why this is here
        _pain = false; //it works, probably?
        Debug.Log("SWITCHED STATE TO: " + currentState);
        StopCoroutine("ChangeState");
    }
}
