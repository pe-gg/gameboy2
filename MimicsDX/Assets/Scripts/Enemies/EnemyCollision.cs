using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : BaseCollision
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void HandleCollision(BaseCollision col)
    {
        Debug.Log(col.gameObject.name);
        TakeKnockback(col);
    }

    private void TakeKnockback(BaseCollision collidedWith)
    {
        Vector3 direction = (collidedWith.transform.position - this.transform.position).normalized;
        _rb.AddForce(2f * -direction, ForceMode2D.Impulse);
    }
}
