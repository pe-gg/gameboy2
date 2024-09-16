using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour
{
    private PlayerHealth health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        health = GetComponent<PlayerHealth>();
    }
    public void UpdateHUD()
    {
        float healthPercent = (float)health.hp / 6f;
        healthBar.fillAmount = healthPercent;
        //Debug.Log("Bar updated! Health is now at " + healthPercent + ", current health is " + stats.health);
    }
}
