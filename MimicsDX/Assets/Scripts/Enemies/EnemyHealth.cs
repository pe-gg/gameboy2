using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int hp;
    private int _previoushp;
    private void FixedUpdate()
    {
        if (hp == _previoushp)
            return;
        UpdateHealth();
    }
    public void TakeDamage(int damage)
    {
        int newHP = hp - damage;
        hp = newHP;
        if (hp <= 0)
        {
            Death();
        }
    }
    private void UpdateHealth()
    {
        _previoushp = hp;
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
