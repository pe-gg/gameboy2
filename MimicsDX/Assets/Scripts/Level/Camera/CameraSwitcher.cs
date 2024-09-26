using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera1;
    [SerializeField] private CinemachineVirtualCamera _camera2;
    public UnityEvent OnSwitch;
    private PlayerController _pc;
    private bool _switch = false;
    private bool _transitioning = false;
    private void Awake()
    {
        _pc = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        SwitchCams();
        OnSwitch?.Invoke();
        StartCoroutine(LockControl());
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

    IEnumerator LockControl()
    {
        _pc.haltMovement = true;
        _transitioning = true;
        StartCoroutine(DumbPainFix());
        yield return new WaitForSeconds(0.75f);
        _pc.haltMovement = false;
        _transitioning = false;
        StopCoroutine("DumbPainFix");
        StopCoroutine("LockControl");
    }

    IEnumerator DumbPainFix()
    {
        while(_transitioning)
        {
            if(_pc.haltMovement == false)
                _pc.haltMovement = true;
            yield return new WaitForFixedUpdate();
        }
    }
}
