using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] _audio;

    private void Awake()
    {
        _audio = GetComponents<AudioSource>();
    }

    public void PlaySFX(int index)
    {
        _audio[index].Play();
    }
    /* THE GREAT AUDIO ID REFERENCE
     * 0 = BGM (temp)
     * 1 = sword swing
     * 2 = player pain
     * 3 = enemy pain
     * 4 = enemy death
     * 5 = health pickup
     * 6 = magicrod shoot
     * 7 = mana pickup
     * 8 = door open/close
     * 9 = pressure plate down
     * 10 = switch0
     * 11 = switch1
     * 12 = switch2
     * 13 = switch3
     */
}
