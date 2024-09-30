using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _spr;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                _anim.SetFloat("MovementX", 0f);
                _anim.SetFloat("MovementY", 1f);
                break;
            case 1:
                _anim.SetFloat("MovementX", 1f);
                _anim.SetFloat("MovementY", 0f);
                _spr.flipX = false;
                break;
            case 2:
                _anim.SetFloat("MovementX", -1f);
                _anim.SetFloat("MovementY", 0f);
                _spr.flipX = true;
                break;
        }
    }

    public void SetAnimation(int anim)
    {
        switch (anim)
        {
            case 0: //Idle
                _anim.SetBool("Attacking", false);
                _anim.SetBool("Stunned", false);
                break;
            case 1: //Attacking
                _anim.SetBool("Attacking", true);
                _anim.SetBool("Stunned", false);
                break;
            case 2: //Stunned
                _anim.SetBool("Attacking", false);
                _anim.SetBool("Stunned", true);
                break;
        }
    }
}
