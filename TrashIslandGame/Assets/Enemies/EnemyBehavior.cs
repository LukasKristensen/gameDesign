using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : Killable
{
    [SerializeField] private Friendly target;
    private NavMeshAgent _navMeshAgent;
    private FriendliesManager _manager;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTimer;
    [SerializeField] private int attackDamage;
    
    
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _manager = FindObjectOfType<FriendliesManager>();
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (target== null)
        {
            target = _manager.friendlies[0];
        }
        foreach (var friendly in _manager.friendlies)
        {
            if ((friendly.transform.position-transform.position).sqrMagnitude < (target.transform.position-transform.position).sqrMagnitude && friendly != target && friendly.targetable)
            {
                target = friendly;
            }
        }

        if ((target.transform.position-transform.position).sqrMagnitude<= attackRange)
        {
            if (attackTimer<= 0)
            {
                Attack();
                attackTimer = 1;
            }
        }
        _navMeshAgent.destination = target.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }

    private void Attack()
    {
        target.TakeDamage(attackDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IDamaging>(out IDamaging damageDealer)) return;
        if (damageDealer.Active)
        {
            TakeDamage(damageDealer.Damage);
        }
    }

    
}
