using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : BaseCollision 
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    private Collider2D _thisCol;
    private PlayerHealth _health;
    private PitSafetyCheck _pitPos;
    private PlayerAnimator _anim;
    private bool isInPain;
    [SerializeField] private int _painDuration;
    private int _defaultPainDuration;

    private bool _inPit;
    private int _pitDuration;
    private void Awake()
    {
        _pc = GetComponentInParent<PlayerController>();
        _rb = GetComponentInParent<Rigidbody2D>();
        _thisCol = GetComponent<Collider2D>();
        _health = GetComponentInParent<PlayerHealth>();
        _pitPos = GetComponentInParent<PitSafetyCheck>();
        _anim = GetComponentInParent<PlayerAnimator>();
        _defaultPainDuration = _painDuration;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            if (_inPit)
                return;
            Debug.Log("pit");
            FellInPit();
        }
    }
    public void HandleCollision(BaseCollision col)
    {
        Debug.Log(col.gameObject.name);
        TakeKnockback(col);
    }

    private void TakeKnockback(BaseCollision collidedWith)
    {
        _thisCol.enabled = false;
        _pc.haltMovement = true;
        isInPain = true;
        Vector3 direction = (collidedWith.transform.position - this.transform.position).normalized;
        _rb.AddForce(7f * -direction, ForceMode2D.Impulse);
        _health.TakeDamage(1);
        StartCoroutine("PainTimer");
    }
    IEnumerator PainTimer()
    {
        while (isInPain)
        {
            _painDuration--;
            if (_painDuration <= 0)
                isInPain = false;
            yield return new WaitForFixedUpdate();
        }
        _pc.haltMovement = false;
        _thisCol.enabled = true;
        _painDuration = _defaultPainDuration;
        yield return new WaitForFixedUpdate();
    }

    private void FellInPit()
    {
        _rb.velocity = Vector3.zero;
        _pc.haltMovement = true;
        _thisCol.enabled = false;
        _inPit = true;
        _anim.FallingSprite();
        StartCoroutine(PitTimer());
    }

    IEnumerator PitTimer()
    {
        yield return new WaitForSeconds(1.5f);
        _pc.haltMovement = false;
        _thisCol.enabled = true;
        _inPit = false;
        _rb.gameObject.transform.position = _pitPos.LastSafePos;
        _health.TakeDamage(1);
        _anim.FallingSprite();
        StopCoroutine(PitTimer());
        yield return new WaitForFixedUpdate();
    }
}
