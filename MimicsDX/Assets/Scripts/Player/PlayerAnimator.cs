using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private PlayerDirection _dir;
    private PlayerSword _sw;
    private PlayerRod _rod;
    private bool _fallFlip = true; //laziness

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _dir = GetComponent<PlayerDirection>();
        _sprite = GetComponent<SpriteRenderer>();
        _sw = GetComponentInChildren<PlayerSword>();
        _rod = GetComponentInChildren<PlayerRod>();
    }

    private void FixedUpdate()
    {
        if (_dir.Direction.x > 0 && _dir.Direction.y == 0)
            _sprite.flipX = true;
        else
            _sprite.flipX = false;
        _animator.SetFloat("MovementX", _dir.Direction.x);
        _animator.SetFloat("MovementY", _dir.Direction.y);
    }

    public void AttackSprite()
    {
        StartCoroutine(AttackTimer());
    }

    private IEnumerator AttackTimer()
    {
        _animator.SetBool("Attacking", true);
        while (_sw._swingCooldown || _rod._swingCooldown) //REPLACE
        {
            yield return new WaitForFixedUpdate();
        }
        _animator.SetBool("Attacking", false);
        yield return new WaitForFixedUpdate();
    }

    public void FallingSprite()
    {
        _animator.SetBool("Falling", _fallFlip);
        _fallFlip = !_fallFlip;
    }

}