using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] public UnityEvent SwitchActivated;
    [SerializeField] public UnityEvent SwitchDeactivated;
    [SerializeField] private SwitchController _controller;
    private CanActivateSwitches _stepper;
    public bool isActivated { get; private set; }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated)
            return;
        CanActivateSwitches check = collision.gameObject.GetComponent<CanActivateSwitches>();
        if (check == null)
            return;
        _stepper = check;
        isActivated = true;
        _controller.IncrementSwitchCount();
        OpenSignal();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != _stepper?.gameObject)
            return;
        isActivated = false;
        _controller.DecrementSwitchCount();
        _stepper = null;
        ExitSignal();
    }

    private void OpenSignal()
    {
        if (_controller.activatedCount != _controller.plates.Length)
            return;
        SwitchActivated.Invoke();
    }

    private void ExitSignal()
    {
        SwitchDeactivated.Invoke();
    }
}
