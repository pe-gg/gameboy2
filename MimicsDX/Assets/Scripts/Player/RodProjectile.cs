using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodProjectile : MonoBehaviour
{
    Rigidbody2D _rb;
    public void AddForce(Vector2 force)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 6)
            return;
        Destroy(this.gameObject);
    }
}
