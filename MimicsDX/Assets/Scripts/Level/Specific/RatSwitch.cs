using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RatSwitch : MonoBehaviour
{
    [SerializeField] public UnityEvent SwitchActivated;
    [SerializeField] private RatSwitchController _controller;
    [SerializeField] private PlateSpriteSO _spriteSO;
    private SpriteRenderer _spr;
    private CanActivateSwitches _stepper;
    public bool isActivated { get; private set; }

    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated)
            return;
        CanActivateSwitches check = collision.gameObject.GetComponentInParent<CanActivateSwitches>();
        if (check == null)
            return;
        _stepper = check;
        isActivated = true;
        _spr.sprite = _spriteSO.frame1;
        _controller.IncrementSwitchCount();
        Destroy(check.gameObject);
        OpenSignal();
    }

    private void OpenSignal()
    {
        if (_controller.activatedCount != _controller.plates.Length)
            return;
        SwitchActivated.Invoke();
    }
}
