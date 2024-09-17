using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;
    private Rigidbody2D _rb;
    private PlayerSword _sw;
    private PlayerRod _rod;
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
