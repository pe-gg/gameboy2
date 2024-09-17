using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    private AudioManager _sfx;
    private void Awake()
    {
        _sfx = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerKeys keys = collision.GetComponent<PlayerKeys>();
            if (keys.keys <= 0)
                return;
            keys.TakeKey();
            _sfx.PlaySFX(8);
            Destroy(this.gameObject);
        }
    }
}
