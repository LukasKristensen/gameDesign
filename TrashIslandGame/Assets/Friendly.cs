using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour
{
    private FriendliesManager _manager;
    private void Start()
    {
        _manager = FindObjectOfType<FriendliesManager>();
        _manager.friendlies.Add(gameObject);
    }

    private void OnDestroy()
    {
        _manager.friendlies.Remove(gameObject);
    }
}
