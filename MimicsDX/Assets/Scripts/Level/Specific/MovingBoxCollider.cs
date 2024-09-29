using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxCollider : MonoBehaviour
{

    private void FixedUpdate()
    {
        this.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RatCollision check = collision.GetComponent<RatCollision>();
        if (check == null)
            return;
        RodProjectile check2 = collision.GetComponentInParent<RodProjectile>();
        Destroy(check2.gameObject);
    }
}
