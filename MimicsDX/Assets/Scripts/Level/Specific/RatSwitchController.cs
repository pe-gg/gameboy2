using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSwitchController : MonoBehaviour
{
    public int activatedCount { get; private set; }
    public RatSwitch[] plates;
    public void IncrementSwitchCount()
    {
        activatedCount++;
    }

    public void DecrementSwitchCount()
    {
        activatedCount--;
    }
}
