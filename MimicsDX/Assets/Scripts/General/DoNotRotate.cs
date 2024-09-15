using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRotate : MonoBehaviour
{
    //private SpriteRenderer _spr;
    private void Awake()
    {
        //_spr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
