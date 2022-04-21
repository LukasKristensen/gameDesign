using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

public class ShooterBehavior : EnemyBehavior
{

    [SerializeField] private GameObject bullet;
    
    
    internal override void Attack()
    {
        BulletScript instantatedBullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<BulletScript>();
        instantatedBullet.target = target.transform;
        animator.SetBool("Attack", true);
    }
}
