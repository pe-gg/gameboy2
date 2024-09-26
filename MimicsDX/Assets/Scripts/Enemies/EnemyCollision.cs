using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : BaseCollision
{
    [SerializeField] protected float knockbackForce;
    protected Rigidbody2D _rb;
    protected EnemyMovement _nav;
    public Collider2D thisCol;
    protected EnemyHealth _health;
    ICombatCollisions check;
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _nav = GetComponentInParent<EnemyMovement>();
        _health = GetComponentInParent<EnemyHealth>();
        thisCol = GetComponent<Collider2D>();
        this.enabled = false;
        Invoke("WeirdColliderFix", 0.1f);
    }

    private void WeirdColliderFix() //I have no idea why, but the collider starts freaking out if I don't do this
    {
        this.enabled = true;
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

    public virtual void HandleCollision(BaseCollision col)
    {
        thisCol.enabled = false;
        Debug.Log(col.gameObject.name);
        TakeKnockback(col);
    }

    private void TakeKnockback(BaseCollision collidedWith)
    {
        if(_nav == null)
        {
            Destroy(_rb.gameObject);
            return;
        }
        _nav.currentState = EnemyMovement.EnemyState.PAIN;
        Vector3 direction = (collidedWith.transform.position - this.transform.position).normalized;
        _rb.AddForce(knockbackForce * -direction, ForceMode2D.Impulse);
        _health.TakeDamage(1);
    }
}
