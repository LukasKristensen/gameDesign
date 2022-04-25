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
    [SerializeField] internal GameObject trashPrefab;
    [SerializeField] private string attackAnimation;
    [SerializeField] private string gettingHitAnimation;
    public Animator animator;
    private NavMeshAgent navmeshagent;
    [SerializeField] private bool stopped;
    public GameVariables gameVariables;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _manager = FindObjectOfType<FriendliesManager>();
        // animator = GetComponent<Animator>();
        navmeshagent = GetComponent<NavMeshAgent>();
        

    }

    private void Start()
    {
        AssignValues();
    }
    internal virtual void AssignValues()
    {
        attackDamage = gameVariables.WalkerDamage;
        health = gameVariables.WalkerHP;
        
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
                Attack();
                attackTimer = 1;
            }
        }

        navmeshagent.isStopped = stopped;
        
        _navMeshAgent.destination = target.transform.position;
    }

    public void Walk()
    {
        stopped = false;
    }

    public void Stop()
    {
        stopped = true;}
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
        animator.Play("Hit");
    }

    public void HitPlayer()
    {
        target.TakeDamage(attackDamage);
    }

    public override void Die()
    {
        Debug.Log("die");
        Instantiate(trashPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    public override void TakeDamage(int damage)
    {
        health -= damage;
        animator.Play("GettingHit");
        if (health <= 0)
        {
            Die();
        }
    }
}
