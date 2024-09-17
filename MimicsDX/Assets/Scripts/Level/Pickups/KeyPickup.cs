using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : BasePickup
{
    private PlayerKeys _keys;
    protected override void Pickup(GameObject player)
    {
        _keys = player.GetComponent<PlayerKeys>();
        _keys.AddKey();
        base.Pickup(player);
    }
}
