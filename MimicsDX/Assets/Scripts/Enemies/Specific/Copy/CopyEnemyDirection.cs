using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyEnemyDirection : PlayerDirection
{

    private void Awake()
    {
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
        this.Direction = _newDir;
    }
}