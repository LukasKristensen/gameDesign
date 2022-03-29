using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Friendly :Killable
{
    public bool targetable = true;
    protected void Awake()
    {
        FindObjectOfType<FriendliesManager>().friendlies.Add(this);
    }

    private void OnDestroy()
    {
        FindObjectOfType<FriendliesManager>().friendlies.Remove(this);
    }
}


public abstract class Killable : MonoBehaviour
{
    [SerializeField] private int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}