using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCollision : EnemyCollision
{
    ICombatCollisions check;
    private BoxCollider2D _newCol;
    private RatAnimator _anim;
    private void Awake()
    {
        this._rb = GetComponentInParent<Rigidbody2D>();
        this.thisCol = GetComponent<Collider2D>();
        _newCol = GetComponent<BoxCollider2D>();
        _anim = GetComponentInParent<RatAnimator>();
        this.enabled = false;
        _newCol.enabled = false;
        Invoke("WeirdColliderFix", 0.1f);
    }

    private void WeirdColliderFix() 
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
        Destroy(this._rb.gameObject);
    }

    public override void HandleCollision(BaseCollision col)
    {
        base.thisCol.enabled = false;
        _newCol.enabled = true;
        _anim.SetPain();
        Debug.Log(col.gameObject.name);
        this.TakeKnockback(col);
    }

    private void TakeKnockback(BaseCollision collidedWith)
    {
        _rb.velocity = Vector3.zero;
        Vector3 direction = (collidedWith.transform.position - this.transform.position).normalized;
        this._rb.AddForce(base.knockbackForce * -direction, ForceMode2D.Impulse);
    }
}
