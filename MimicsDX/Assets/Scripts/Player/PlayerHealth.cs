using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private HUDView _view;
    public int hp;
    private int _previoushp;
    private void Start()
    {
        _view = GetComponent<HUDView>();
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
    }
    public void Heal(int amount)
    {
        int newHP = hp + amount;
        hp = newHP;
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
