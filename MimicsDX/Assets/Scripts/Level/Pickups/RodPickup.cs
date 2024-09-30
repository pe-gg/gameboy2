using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodPickup : BasePickup
{
    private PlayerRod _rod;
    private HUDView _hud;
    private AudioManager _sfx;
    protected override void Pickup(GameObject player)
    {
        _rod = player.GetComponentInChildren<PlayerRod>();
        _hud = player.GetComponent<HUDView>();
        _sfx = FindObjectOfType<AudioManager>();
        _sfx.PlaySFX(20);
        _rod.hasRod = true;
        _hud.AddRodToHUD();
        base.Pickup(player);
    }
}
