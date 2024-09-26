using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class MageAnimation : MonoBehaviour //this is so awful. i will set up a proper system next time
{
    private Animator _an;
    private MageMovement _en;
    private SpriteRenderer _spr;
    private bool _isAttacking = false;
    private void Awake()
    {
        _en = GetComponentInParent<MageMovement>();
        _an = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        HandleAnimation();
    }
    private void HandleAnimation()
    {
        int x = 0;
        int y = 0;
        if (_en.gameObject.transform.localEulerAngles.x >= 225f && _en.gameObject.transform.localEulerAngles.x <= 315f) //up
        {
            x = 0;
            y = 1;
            UpdateAnimation(x, y);
        }
        else if (_en.gameObject.transform.localEulerAngles.x >= 45f && _en.gameObject.transform.localEulerAngles.x <= 135f) //down
        {
            x = 0;
            y = -1;
            UpdateAnimation(x, y);
        }
        else
        {
            if (_en.gameObject.transform.localEulerAngles.y > 80f && _en.gameObject.transform.localEulerAngles.y < 260f) //right
            {
                x = -1;
                y = 0;
                _spr.flipX = true;
                UpdateAnimation(x, y);
            }
            else //left
            {
                x = 1;
                y = 0;
                _spr.flipX = false;
                UpdateAnimation(x, y);
            }
        }
    }

    public void ToggleAttack()
    {
        _isAttacking = !_isAttacking;
        _an.SetBool("IsAttacking", _isAttacking);
    }

    private void UpdateAnimation(int x, int y)
    {
        _an.SetFloat("MovementX", x);
        _an.SetFloat("MovementY", y);
    }
}