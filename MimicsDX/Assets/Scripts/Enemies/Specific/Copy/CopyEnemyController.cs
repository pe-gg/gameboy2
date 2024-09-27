using UnityEngine;

public class CopyEnemyController : PlayerController
{
    private PlayerController _player;
    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_player.haltMovement)
            return;
        PlayerMovement();
    }

    public void HandleMovementInput(Vector2 input)
    {
        movement = input.normalized;
    }

    private void PlayerMovement()
    {
        if (_player._sw._swingCooldown || _player._rod._swingCooldown || _player.haltMovement)
            _rb.velocity = Vector3.zero;
        else
            _rb.velocity = movement * (_movementSpeed * Time.fixedDeltaTime);
    }
}
