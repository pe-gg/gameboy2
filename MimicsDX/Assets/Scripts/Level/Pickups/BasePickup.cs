using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        GameObject player = collision.gameObject;
        Pickup(player);
    }

    protected virtual void Pickup(GameObject player)
    {
        Destroy(this.gameObject);
    }
}
