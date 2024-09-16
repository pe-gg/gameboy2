using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private HUDView _view;
    public int hp;
    private int _previoushp;
    private int _maxHealth;
    private AudioManager _sfx; //again, probably shouldnt be here
    private void Awake()
    {
        _view = GetComponent<HUDView>();
        _sfx = FindObjectOfType<AudioManager>();
        _maxHealth = hp;
    }
    private void FixedUpdate()
    {
        if (hp == _previoushp)
            return;
        UpdateHealth();
        _view.UpdateHUD();
    }
    public void TakeDamage(int damage)
    {
        int newHP = hp - damage;
        hp = newHP;
        if (hp <= 0)
        {
            PlayerDeath();
        }
        _sfx.PlaySFX(2);
    }
    public void Heal(int amount)
    {
        if (hp >= _maxHealth)
            return;
        int newHP = hp + amount;
        hp = newHP;
        _sfx.PlaySFX(5);
    }
    private void UpdateHealth()
    {
        _previoushp = hp;
    }
    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
