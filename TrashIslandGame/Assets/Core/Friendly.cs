using System;
using System.Collections;
using System.Collections.Generic;
using Core;

public abstract class Friendly :Killable
{
    public bool targetable = true;
    private FriendliesManager fm;
    protected void Awake()
    {
        fm = FindObjectOfType<FriendliesManager>();
        fm?.Add(this);
    }

    private void OnDestroy()
    {
        fm?.Remove(this);
    }
}