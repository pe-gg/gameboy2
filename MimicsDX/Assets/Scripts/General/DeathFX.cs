using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFX : MonoBehaviour
{
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        Invoke("Die", 0.4f);
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
