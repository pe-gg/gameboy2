using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : BaseCollision
{
    [SerializeField] private float knockbackForce;
    private Rigidbody2D _rb;
    private EnemyMovement _nav;
    public Collider2D thisCol;
    private EnemyHealth _health;
    ICombatCollisions check;
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _nav = GetComponentInParent<EnemyMovement>();
        _health = GetComponentInParent<EnemyHealth>();
        thisCol = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.identity;
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
        thisCol.enabled = false;
        Debug.Log(col.gameObject.name);
        TakeKnockback(col);
    }

    private void TakeKnockback(BaseCollision collidedWith)
    {
        _nav.currentState = EnemyMovement.EnemyState.PAIN;
        Vector3 direction = (collidedWith.transform.position - this.transform.position).normalized;
        _rb.AddForce(knockbackForce * -direction, ForceMode2D.Impulse);
        _health.TakeDamage(1);
    }
}
