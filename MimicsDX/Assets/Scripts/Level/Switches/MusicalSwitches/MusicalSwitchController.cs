using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicalSwitchController : MonoBehaviour
{
    [SerializeField] private MusicalSwitch[] _switches;
    public UnityEvent SwitchHit;
    public UnityEvent AllSwitchesActive;
    private bool _check;
    private int _numberMatch;

    public void ReceiveSignal(int id)
    {
        int newNum = _numberMatch + id;
        _numberMatch = newNum;
        NumberCheck();
    }

    private void NumberCheck()
    {
        if (_numberMatch == 10)
        {
            Debug.Log("Switch 4 hit");
            AllSwitchesActive?.Invoke();
            return;
        }
        else if (_numberMatch == 6)
        {
            Debug.Log("Switch 3 hit");
            return;
        }
        else if (_numberMatch == 3 && _check)
        {
            Debug.Log("Switch 2 hit");
            return;
        }
        else if(_numberMatch == 1)
        {
            Debug.Log("Switch 1 hit");
            _check = true;
            return;
        }
        else
        {
            _check = false;
            Wrong();
        }
    }

    private void Wrong()
    {
        _numberMatch = 0;
        Debug.Log("Wrong order!");
        SwitchHit?.Invoke();
        foreach (MusicalSwitch sw in _switches)
        {
            sw.TurnOff();
        }
    }
}
