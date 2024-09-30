using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnimator : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _spr;
    private bool _update;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (_update)
            return;
        if (_rb.velocity.x > 0)
            _spr.flipX = true;
        else
            _spr.flipX = false;
        _anim.SetFloat("MovementX", _rb.velocity.normalized.x);
        _anim.SetFloat("MovementY", _rb.velocity.normalized.y);
        _update = true;
    }


    public void SetPain()
    {
        _anim.SetBool("Pain", true);
    }
}
