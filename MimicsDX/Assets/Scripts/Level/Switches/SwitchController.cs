using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public int activatedCount { get; private set; }
    public PressurePlate[] plates;
    public void IncrementSwitchCount()
    {
        activatedCount++;
    }

    public void DecrementSwitchCount()
    {
        activatedCount--;
    }
}
