using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : BaseCollision
{
    ICombatCollisions check;
    private void OnTriggerEnter2D(Collider2D other)
    {
        check = other.GetComponent<ICombatCollisions>();
        if (check == null)
            return;
        EnemyCollision check2 = other.GetComponent<EnemyCollision>();
        if (check2 == null)
            return;
        check2.HandleCollision(this);
    }
    public void HandleCollision()
    {
        
    }
}
