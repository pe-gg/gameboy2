using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : BaseCollision 
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    private Collider2D _thisCol;
    private bool isInPain;
    [SerializeField] private int _painDuration;
    private int _defaultPainDuration;
    private void Awake()
    {
        _pc = GetComponentInParent<PlayerController>();
        _rb = GetComponentInParent<Rigidbody2D>();
        _thisCol = GetComponent<Collider2D>();
        _defaultPainDuration = _painDuration;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

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
        _rb.AddForce(10f * -direction, ForceMode2D.Impulse);
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
        Debug.Log("EndOfPain");
        yield return new WaitForFixedUpdate();
    }
}
