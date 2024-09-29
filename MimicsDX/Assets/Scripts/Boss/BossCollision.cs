using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : BaseCollision
{
    private ICombatCollisions check;
    private Collider2D _thisCol;
    private BossStates _state;
    private EnemyHealth _health;
    private void Awake()
    {
        _thisCol = GetComponent<Collider2D>();
        _state = GetComponent<BossStates>();
        _health = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        check = other.GetComponent<ICombatCollisions>();
        if (check == null)
            return;
        PlayerCollision check2 = other.GetComponent<PlayerCollision>();
        if (check2 == null)
            return;
        check2.HandleCollision(this);
    }
    public void HandleCollision(BaseCollision col)
    {
        //_thisCol.enabled = false;
        Debug.Log("BOSS HIT BY " + col.gameObject.name);
        RatCollision ratCheck = col.GetComponent<RatCollision>();
        if (ratCheck == null)
            PainSignal();
        else
            StunSignal();
    }

    private void PainSignal()
    {
        if (_state.currentState != BossStates.BossState.VULNERABLE)
        {
            Debug.Log("CANNOT BE HIT NOW!");
            return;
        }
        _state.currentState = BossStates.BossState.PAIN;
        _health.TakeDamage(1);
    }
    private void StunSignal()
    {
        Debug.Log("STUNNED?");
        _state.currentState = BossStates.BossState.VULNERABLE;
    }
}
