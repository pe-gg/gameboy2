using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : BasePickup
{
    private PlayerMana _mana;
    protected override void Pickup(GameObject player)
    {
        _mana = player.GetComponent<PlayerMana>();
        _mana.RestoreMana(30);
        base.Pickup(player);
    }
}
