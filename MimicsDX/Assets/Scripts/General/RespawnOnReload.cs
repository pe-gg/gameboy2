using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnReload : MonoBehaviour
{
    private Vector2 _spawnPos;
    private void Awake()
    {
        _spawnPos = this.gameObject.transform.position;
    }

    private void OnEnable()
    {
        this.gameObject.transform.position = _spawnPos;
    }
}
