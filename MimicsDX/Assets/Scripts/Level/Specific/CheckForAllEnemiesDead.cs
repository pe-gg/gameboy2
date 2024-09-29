using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckForAllEnemiesDead : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private int _enemiesInRoom;
    public UnityEvent OnEnemiesCleared;

    public void EnemyDeath()
    {
        _enemiesInRoom--;
        if(_enemiesInRoom <= 0)
            OnEnemiesCleared?.Invoke();
    }
}
