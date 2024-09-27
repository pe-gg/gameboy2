using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] private RodProjectile _rat;

    private void Awake()
    {
        StartCoroutine(RatSpawnLoop());
    }
    private void SpawnObject()
    {
        RodProjectile rat = Instantiate(_rat, this.transform.position, Quaternion.identity);
        rat.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 9.126616f); //stupid specific number so that it collides with the damn block
        rat.AddForce(Vector2.right * 5f);
    }

    private IEnumerator RatSpawnLoop()
    {
        SpawnObject();
        yield return new WaitForSeconds(3f);
        StartCoroutine(RatSpawnLoop());
    }
}
