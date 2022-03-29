using System;
using System.Collections;
using System.Collections.Generic;
using PellesAssets;
using Stations;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildMenuScript : MonoBehaviour
{
    private FPSInputs _fpsInputs;
    [SerializeField] private FPSController _fpsController;
    public Building currentBuilding;
    
    public GameObject CraftingStation;

    public GameObject tempBuilding;
    void Start()
    {
        _fpsInputs = new FPSInputs();
        _fpsInputs.Default.Attack.Enable();
        _fpsInputs.Default.Attack.performed += Build;
        tempBuilding = Instantiate(CraftingStation);
        tempBuilding.GetComponent<Friendly>().targetable = false;
    }

    private void Build(InputAction.CallbackContext obj)
    {
        if (_fpsController._inventory.ChangeInventory(currentBuilding.cost))
        {
            tempBuilding.GetComponent<Friendly>().targetable = true;
            tempBuilding = Instantiate(CraftingStation,Vector3.up, Quaternion.identity);
            tempBuilding.GetComponent<Friendly>().targetable = false;
        }
        
    }

    private void OnEnable()
    {
        if (tempBuilding ==null)
        {
            return;
        }
        tempBuilding.SetActive(true);
    }

    private void OnDisable()
    {
        tempBuilding.SetActive(false);
    }

    void Update()
    {
        if (tempBuilding ==null)
        {
            return;
        }
        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            if (hit.collider.gameObject.layer == 3)
            {
                tempBuilding.transform.position = hit.point+Vector3.up*0.5f;
            }
        }
    }
}
