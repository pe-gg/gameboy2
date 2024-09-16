using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int _hp;
    private int _previoushp;
    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        if (_hp == _previoushp)
            return;
        UpdateHealth();
    }
    public void TakeDamage(int damage)
    {
        if (_hp <= 0)
        {
            PlayerDeath();
        }
        _hp = _hp - damage;
    }
    public void Heal(int amount)
    {
        _hp = _hp + amount;
    }
    private void UpdateHealth()
    {
        _previoushp = _hp;
    }
    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
