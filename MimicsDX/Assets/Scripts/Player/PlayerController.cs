using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 150f;
    [SerializeField] protected float _xSpeed;
    [SerializeField] protected float _ySpeed;
    public Rigidbody2D _rb { get; protected set; }
    public PlayerSword _sw { get; protected set; }
    public PlayerRod _rod { get; protected set; }
    public Vector2 movement;
    public bool haltMovement;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sw = GetComponentInChildren<PlayerSword>();
        _rod = GetComponentInChildren<PlayerRod>();
    }

    void FixedUpdate()
    {
        if (haltMovement)
            return;
         PlayerMovement();
    }

    public void HandleMovementInput(Vector2 input)
    {
        movement = input.normalized;
    }

    private void PlayerMovement()
    {
        if (_sw._swingCooldown || _rod._swingCooldown) //REPLACE
            _rb.velocity = Vector2.zero;
        else
            _rb.velocity = movement * (_movementSpeed * Time.fixedDeltaTime);
    }
}
