using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCollision : BaseCollision
{
    private RodProjectile _parent;
    ICombatCollisions check;
    private void Awake()
    {
        _parent = GetComponentInParent<RodProjectile>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        check = other.GetComponent<ICombatCollisions>();
        if (check == null)
            return;
        EnemyCollision check2 = other.GetComponent<EnemyCollision>();
        BossCollision check3 = other.GetComponent<BossCollision>();
        if (check2 == null && check3 == null)
            return;
        if (check2 == null && check3 != null)
            check3.HandleCollision(this);
        else
            check2.HandleCollision(this);
        Destroy(_parent.gameObject);
    }
    public void HandleCollision()
    {

    }
}
