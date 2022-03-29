using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("trying to Deal Damage");
        if (!other.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy)) return;
        if (Active)
        {
            enemy.TakeDamage(Damage);
            Debug.Log("dealing damage");
        } throw new NotImplementedException();
    }

    

   
}
