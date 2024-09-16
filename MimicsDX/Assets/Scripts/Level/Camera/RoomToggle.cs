using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomToggle : MonoBehaviour
{
    private bool _currentState;
    private void Awake()
    {
        _currentState = transform.GetChild(0).gameObject.activeSelf;
    }
    public void Toggle()
    {
        _currentState = !_currentState;
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if (_currentState == true)
            Invoke("ReEnable", 0.75f);
    }

    private void ReEnable()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
