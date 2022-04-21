using System;
using System.Collections;
using System.Collections.Generic;
using Equipment;
using UnityEngine;

public class SpearController : EquippableController
{
    [SerializeField] private List<GameObject> SpearPrefabs;
    [SerializeField] private Spear currentSpear;

    private void Start()
    {
        currentSpear = Instantiate(SpearPrefabs[currentTeir], transform).GetComponent<Spear>();
    }

    public void Fire()
    {
        currentSpear.Fire();
    }

    public override void Upgrade()
    {
        Destroy(currentSpear.gameObject);
        currentTeir++;
        currentSpear = Instantiate(SpearPrefabs[currentTeir], transform).GetComponent<Spear>();
    }
}

public class EquippableController : MonoBehaviour
{
    public int currentTeir = 0;

    public virtual void Upgrade()
    {
        
    }
}
