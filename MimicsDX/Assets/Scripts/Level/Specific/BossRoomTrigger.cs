using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossRoomTrigger : MonoBehaviour
{
    public UnityEvent Triggered;
    private bool _active;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_active)
            return;
        _active = true;
        Triggered?.Invoke();
        Destroy(this.gameObject, 0.1f);
    }
}
