using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] DeathFX _fx;
    public int hp;
    private int _previoushp;
    private AudioManager _sfx; //this probably shouldn't be here, but whatever
    public UnityEvent OnEnemyDeath;
    private void Awake()
    {
        _sfx = FindObjectOfType<AudioManager>();
    }
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
        _sfx.PlaySFX(3);
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
        _sfx.PlaySFX(4);
        OnEnemyDeath?.Invoke();
        Instantiate(_fx, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
