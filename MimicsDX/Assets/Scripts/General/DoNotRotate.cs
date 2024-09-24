using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRotate : MonoBehaviour
{
    private Vector3 rot;
    private void Awake()
    {
        rot = new Vector3(0f, 0f, 0f);
    }

    private void FixedUpdate()
    {
        this.transform.localEulerAngles = rot;
    }
}
