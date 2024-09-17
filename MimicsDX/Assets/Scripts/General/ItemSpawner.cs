using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;

    public void SpawnObject()
    {
        Instantiate(_objectToSpawn, this.transform.position, Quaternion.identity);
    }
}
