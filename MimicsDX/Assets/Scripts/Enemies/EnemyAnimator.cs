using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _an;
    private EnemyMovement _en;
    private SpriteRenderer _spr;
    private void Awake()
    {
        _en = GetComponentInParent<EnemyMovement>();
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
            if(_en.gameObject.transform.localEulerAngles.y > 80f && _en.gameObject.transform.localEulerAngles.y < 260f) //right
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

    private void UpdateAnimation(int x, int y)
    {
        _an.SetFloat("MovementX", x);
        _an.SetFloat("MovementY", y);
    }
}
