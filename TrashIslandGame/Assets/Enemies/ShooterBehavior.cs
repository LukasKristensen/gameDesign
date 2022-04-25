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
    [SerializeField] private Transform HandPoint;
    

    internal override bool AttackCheck()
    {
        if ((target.transform.position - transform.position).magnitude <= attackRange)
        {
             Physics.Raycast(transform.position, (target.transform.position-transform.position) * attackRange,out RaycastHit hit);
             if (hit.collider.CompareTag("Player"))
             {
                 return true;
             }
        }
        return false;
    }
    internal override void Attack()
    {
        animator.Play("Hit");
    }

    public void Shoot()
    {
        BulletScript instantatedBullet = Instantiate(bullet, HandPoint.position, Quaternion.identity).GetComponent<BulletScript>();
        instantatedBullet.target = target.transform;
    }
}
