using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Shield : Equippable
{

    public bool blocking;
    public int damageBlocked;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = blocking? startPosition+offset: startPosition;
    }

    public int getBlockValue()
    {
        return damageBlocked;
    }
}
