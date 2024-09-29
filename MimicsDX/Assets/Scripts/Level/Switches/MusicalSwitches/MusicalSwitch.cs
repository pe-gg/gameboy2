using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalSwitch : MonoBehaviour
{
    [SerializeField] private int _sndID;
    [SerializeField] private int _switchID;
    [SerializeField] private MusicalSwitchController _ctrl;
    [SerializeField] private PlateSpriteSO _frame;
    private AudioManager _sfx;
    private SpriteRenderer _spr;
    private bool _turnedOn;
    private Collider2D _col;
    private void Awake()
    {
        _sfx = FindObjectOfType<AudioManager>();
        _col = GetComponent<Collider2D>();
        _spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RodCollision check = collision.GetComponent<RodCollision>();
        if (check == null)
            return;
        _col.enabled = false;
        Debug.Log("Switch hit!");
        _turnedOn = true;
        _spr.sprite = _frame.frame1;
        _sfx.PlaySFX(_sndID);
        _ctrl.ReceiveSignal(_switchID);
    }

    public void TurnOff()
    {
        StartCoroutine("EnableDelay");
    }
    private IEnumerator EnableDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _turnedOn = false;
        _col.enabled = true;
        _spr.sprite = _frame.frame0;
        StopCoroutine("EnableDelay");
    }
}
