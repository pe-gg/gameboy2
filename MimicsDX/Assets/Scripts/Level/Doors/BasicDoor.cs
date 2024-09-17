using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    private Collider2D _col;
    private SpriteRenderer _spr;
    private AudioManager _sfx;
    public bool doorSolved = false;
    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _spr = GetComponent<SpriteRenderer>();
        _sfx = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        if (doorSolved)
            this.gameObject.SetActive(false);
    }
    public void Open()
    {
        if (doorSolved)
            return;
        _col.enabled = false;
        _spr.enabled = false;
        _sfx.PlaySFX(8);
    }

    public void Close() 
    {
        if(doorSolved)
            return;
        _col.enabled = true;
        _spr.enabled = true;
        _sfx.PlaySFX(8);
    }

    public void SetSolved()
    {
        if (doorSolved)
            return;
        doorSolved = true;
    }

    public void ToggleDoor() //might need this later
    {
        _col.enabled = !_col.enabled;
        _spr.enabled = !_spr.enabled;
    }

}
