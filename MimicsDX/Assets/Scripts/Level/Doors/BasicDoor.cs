using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    private Collider2D _col;
    private SpriteRenderer _spr;
    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _spr = GetComponent<SpriteRenderer>();
    }
    public void Open()
    {
        _col.enabled = false;
        _spr.enabled = false;
    }

    public void Close() 
    {
        _col.enabled = true;
        _spr.enabled = true;
    }

    public void ToggleDoor() //might need this later
    {
        _col.enabled = !_col.enabled;
        _spr.enabled = !_spr.enabled;
    }
}
