using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : BasePickup
{
    private PlayerHealth health;
    protected override void Pickup(GameObject player)
    {
        health = player.GetComponent<PlayerHealth>();
        health.Heal(1);
        base.Pickup(player);
    }
}
