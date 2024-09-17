using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    private HUDView _view;
    public int mana;
    private int _previousMana;
    public int maxMana;
    private AudioManager _sfx; 
    private void Awake()
    {
        _view = GetComponent<HUDView>();
        _sfx = FindObjectOfType<AudioManager>();
        maxMana = mana;
    }
    private void FixedUpdate()
    {
        if (mana == _previousMana)
            return;
        UpdateMana();
        _view.UpdateHUD();
    }
    public void TakeMana(int amount)
    {
        int newMana = mana - amount;
        mana = newMana;
    }
    public void RestoreMana(int amount)
    {
        if (mana >= maxMana)
            return;
        int newMana = mana + amount;
        mana = Mathf.Clamp(newMana, 0, maxMana);
        _sfx.PlaySFX(7);
    }
    private void UpdateMana()
    {
        _previousMana = mana;
    }
}
