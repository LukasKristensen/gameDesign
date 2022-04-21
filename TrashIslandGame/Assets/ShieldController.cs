using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldController : EquippableController
{
    [SerializeField] private List<GameObject> SheildPrefabs;
    [SerializeField] private Shield currentShield;
    public bool blocking;
    private void Start()
    {
        currentShield = Instantiate(SheildPrefabs[currentTeir], transform).GetComponent<Shield>();
    }

    private void Update()
    {
        currentShield.blocking = blocking;
    }
    public int getBlockValue()
    {
        return currentShield.getBlockValue();
    }
    public override void Upgrade()
    {
        Destroy(currentShield.gameObject);
        currentTeir++;
        currentShield = Instantiate(SheildPrefabs[currentTeir], transform).GetComponent<Shield>();
    }
}
