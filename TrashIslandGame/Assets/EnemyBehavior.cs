using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField, Range(1,10)] private int hitPoints = 10;
    private NavMeshAgent _navMeshAgent;
    private FriendliesManager _manager;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
        _manager = FindObjectOfType<FriendliesManager>();
    }

    private void Update()
    {
        foreach (var friendly in _manager.friendlies)
        {
            if ((friendly.transform.position-transform.position).sqrMagnitude < (target.transform.position-transform.position).sqrMagnitude && friendly != target)
            {
                target = friendly;
            }
        }
        _navMeshAgent.destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IDamaging>(out IDamaging damageDealer)) return;
        if (damageDealer.Active)
        {
            TakeDamage(damageDealer.Damage);
        }
    }

    private void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
