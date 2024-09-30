using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    private HUDView _view;
    public int keys;
    private int _previousKeys;
    private AudioManager _sfx;
    private void Awake()
    {
        _view = GetComponent<HUDView>();
        _sfx = FindObjectOfType<AudioManager>();
    }
    private void FixedUpdate()
    {
        if (keys == _previousKeys)
            return;
        UpdateKeyCount();
        _view.UpdateKeys();
    }
    public void TakeKey()
    {
        keys--;
    }
    public void AddKey()
    {
        keys++;
        _sfx.PlaySFX(17);
    }
    private void UpdateKeyCount()
    {
        _previousKeys = keys;
    }
}
