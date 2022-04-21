using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

public class EnemyBehavior : Killable
{
    [SerializeField] internal Friendly target;
    internal NavMeshAgent _navMeshAgent;
    internal FriendliesManager _manager;
    [SerializeField] internal float attackRange;
    [SerializeField] internal float attackTimer;
    [SerializeField] internal int attackDamage;
    [SerializeField] internal GameObject arm1;
    [SerializeField] internal GameObject arm2;
    [SerializeField] internal GameObject trashPrefab;
    public Animator animator;
    private NavMeshAgent navmeshagent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _manager = FindObjectOfType<FriendliesManager>();
        // animator = GetComponent<Animator>();
        navmeshagent = GetComponent<NavMeshAgent>();
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

        if (AttackCheck())
        {
            if (attackTimer<= 0)
            {
                // navmeshagent.enabled = false;
                Attack();
                attackTimer = 1;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            // navmeshagent.enabled = true;
        }

        if (!animator.GetBool("Attack"))
        {
            _navMeshAgent.destination = target.transform.position;
        }
        

        if (health<=5)
        {
            arm1.SetActive(false);
            arm2.SetActive(false);
        }
    }

    internal virtual bool AttackCheck()
    {

        return (target.transform.position - transform.position).magnitude <= attackRange;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
    internal virtual void Attack()
    {
        target.TakeDamage(attackDamage);
        animator.SetBool("Attack", true);

    }
    public override void Die()
    {
        Instantiate(trashPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    
}
