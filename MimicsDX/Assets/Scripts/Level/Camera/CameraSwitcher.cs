using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera1;
    [SerializeField] private CinemachineVirtualCamera _camera2;
    private bool _switch = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        SwitchCams();
    }

    private void SwitchCams()
    {
        if (!_switch)
        {
            _camera1.gameObject.SetActive(false);
            _camera2.gameObject.SetActive(true);
            _switch = !_switch;
        }
        else
        {
            _camera2.gameObject.SetActive(false);
            _camera1.gameObject.SetActive(true);
            _switch = !_switch;
        }
    }
}
