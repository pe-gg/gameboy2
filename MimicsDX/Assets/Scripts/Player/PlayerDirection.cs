using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    private Vector2 _newDir;
    private PlayerController _pc;
    private PlayerSword _sw;
    private PlayerRod _rod;

    private void Awake()
    {
        _sw = GetComponentInChildren<PlayerSword>();
        _rod = GetComponentInChildren<PlayerRod>();
        _pc = GetComponent<PlayerController>();
    }
    public void GetMovementInput(Vector2 input)
    {
        _newDir = input.normalized;
    }

    private void FixedUpdate()
    {
        if (_pc.movement.sqrMagnitude > 0.01f && !_pc.haltMovement) 
            UpdateFacingDirection();
    }

    private void UpdateFacingDirection()
    {
        if (_sw._swingCooldown || _rod._swingCooldown)
            return;
        Direction = _newDir;
    }

    public void CacheLastInput(Vector2 input)
    {
        Debug.Log("x = " + input.normalized.x + ", y = " + input.normalized.y);
    }
}
