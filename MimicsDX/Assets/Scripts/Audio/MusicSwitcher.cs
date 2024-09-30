using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private int _mus;
    private AudioManager _sfx;
    private void Awake()
    {
        _sfx = FindObjectOfType<AudioManager>();
    }

    public void Switch()
    {
        _sfx.ChangeMus(0, _mus);
    }
}
