using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitSafetyCheck : MonoBehaviour
{
    public Vector3 LastSafePos { get; private set; }
    private bool _running = true;
    private PlayerController _pc;
    private void Awake()
    {
        _pc = GetComponent<PlayerController>();
        StartCoroutine(CheckForSafeFloor());
    }
    private void FixedUpdate()
    {
        if (_pc.haltMovement)
            _running = false;
        else
            _running = true;
    }
    private IEnumerator CheckForSafeFloor()
    {
        yield return new WaitForSeconds(1f);
        if (_running)
            LogPosition();
        StartCoroutine(CheckForSafeFloor());
    }
    private void LogPosition()
    {
        //Debug.Log("logged");
        LastSafePos = this.transform.position;
    }

    public void ScreenTransition()
    {
        StartCoroutine(WaitForScreen());
    }

    private IEnumerator WaitForScreen()
    {
        yield return new WaitForSeconds(0.75f);
        LogPosition();
    }
}
