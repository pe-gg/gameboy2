using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRod : MonoBehaviour //THIS SCRIPT IS NOT STAYING LIKE THIS. WILL BE REFACTORING INTO PROPER WEAPON BASE SCRIPT
{
    [SerializeField] private SwordSpriteSO _spr;
    [SerializeField] private SpriteRenderer _visual;
    [SerializeField] private float _swingSpeed = 3f;
    [SerializeField] private int _swordDuration = 20;
    [SerializeField] private RodProjectile _proj;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private int _manaCost;
    private PlayerController _pc;
    private PlayerDirection _dir;
    private AudioManager _sfx;
    private PlayerMana _mana;

    private bool _swinging;
    public bool _swingCooldown { private set; get; }
    private int _swingTimer;

    private void Awake()
    {
        _pc = GetComponentInParent<PlayerController>();
        _dir = GetComponentInParent<PlayerDirection>();
        _sfx = FindObjectOfType<AudioManager>();
        _mana = GetComponentInParent<PlayerMana>();
        _visual.enabled = false;
    }

    private void FixedUpdate()
    {
        if (!_swingCooldown)
            this.transform.rotation = FacingQuaternion();
    }

    public void StartAttack()
    {

        if (_swingCooldown || _pc.haltMovement || _mana.mana < _manaCost)
            return;
        _visual.enabled = true;
        _swinging = true;
        StartCoroutine(SwordSwing());
        _swingCooldown = true;
        _sfx.PlaySFX(6);
    }

    IEnumerator SwordSwing()
    {
        UpdateSwordRotation();
        yield return new WaitForSeconds(0.05f);
        while (_swinging)
        {
            if (FacingDirection() == 2)
                this.transform.Rotate(0, 0, -_swingSpeed);
            else
                this.transform.Rotate(0, 0, _swingSpeed);
            _swingTimer++;
            _visual.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            UpdateSwordFrame();
            if (_swingTimer == _swordDuration)
                _swinging = false;
            yield return new WaitForFixedUpdate();
        }
        _swingTimer = 0;
        FireProjectile();
        _mana.TakeMana(_manaCost);
        yield return new WaitForSeconds(0.1f);
        _visual.enabled = false;
        _swingCooldown = false;
        this.transform.rotation = FacingQuaternion();
        yield return new WaitForFixedUpdate();
    }

    private void FireProjectile()
    {
        Vector2 forceDir = Vector2.zero;
        Vector3 fireOffset = Vector3.zero;
        switch (FacingDirection())
        {
            case 0:
                forceDir = Vector2.up;
                fireOffset = new Vector3(0, 1, 0);
                break;
            case 1:
                forceDir = Vector2.down;
                fireOffset = new Vector3(0, -1, 0);
                break;
            case 2:
                forceDir = Vector2.right;
                fireOffset = new Vector3(1, 0, 0);
                break;
            case 3:
                forceDir = Vector2.left;
                fireOffset = new Vector3(-1, 0, 0);
                break;
        }
        RodProjectile firedProjectile = Instantiate(_proj, this.transform.position + fireOffset, Quaternion.identity);
        firedProjectile.AddForce(forceDir * _projectileSpeed);
    }

    private Quaternion FacingQuaternion()
    {
        Quaternion q = Quaternion.Euler(0, 0, 0);
        switch (FacingDirection())
        {
            case 0:
                return q;
            case 1:
                q = Quaternion.Euler(0, 0, 180);
                return q;
            case 2:
                q = Quaternion.Euler(0, 0, 75);
                return q;
            case 3:
                q = Quaternion.Euler(0, 0, 80);
                return q;
        }
        return q;
    }

    private int FacingDirection()
    {
        if (_dir.Direction.y > 0)
            return 0;
        else if (_dir.Direction.y < 0)
            return 1;
        else if (_dir.Direction.x > 0 && _dir.Direction.y <= 0)
            return 2;
        else if (_dir.Direction.x < 0 && _dir.Direction.y <= 0)
            return 3;
        else return 0;
    }

    //0 = up            0
    //1 = down      3       2
    //2 = right         1
    //3 = left

    private void UpdateSwordFrame()
    {
        if (FacingDirection() > 1)
        {
            if (_swingTimer > _swordDuration / 1.5f)
                _visual.sprite = _spr.frame0;
            else if (_swingTimer > _swordDuration / 3f)
                _visual.sprite = _spr.frame1;
            else
                _visual.sprite = _spr.frame2;
            return;
        }
        if (_swingTimer > _swordDuration / 1.5f)
            _visual.sprite = _spr.frame2;
        else if (_swingTimer > _swordDuration / 3f)
            _visual.sprite = _spr.frame1;
        else
            _visual.sprite = _spr.frame0;
    }

    private void UpdateSwordRotation()
    {
        switch (FacingDirection())
        {
            case 0:
                _visual.flipY = false;
                _visual.flipX = false;
                return;
            case 1:
                _visual.flipY = true;
                _visual.flipX = true;
                return;
            case 2:
                _visual.flipY = false;
                _visual.flipX = false;
                return;
            case 3:
                _visual.flipY = false;
                _visual.flipX = true;
                return;
        }
    }
}