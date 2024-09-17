using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour
{
    private PlayerHealth _health;
    private PlayerMana _mana;
    private PlayerKeys _keys;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image[] keys;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _mana  = GetComponent<PlayerMana>();
        _keys = GetComponent<PlayerKeys>();
    }
    public void UpdateHUD()
    {
        float healthPercent = (float)_health.hp / 6f;
        _healthBar.fillAmount = healthPercent;
        float manaPercent = (float)_mana.mana / _mana.maxMana;
        _manaBar.fillAmount = manaPercent;
    }

    public void UpdateKeys()
    {
        for (int i = 0; i < _keys.keys; i++)
        {
            keys[i].gameObject.SetActive(true);
            keys[Mathf.Clamp(i + _keys.keys, 0, keys.Length)].gameObject.SetActive(false);
        }
        if (_keys.keys == 0) //if player has no keys, set all keys disabled - this is to handle an edge case when the player only has one key
        {
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].gameObject.SetActive(false);
            }
        }
        //Debug.Log("keys updated!");
    }
}
