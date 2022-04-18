using System;
using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public Label hp;
    public Label plastic;
    public Label metal;
    public Inventory inventory;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        hp = root.Q<Label>("health-label");
        plastic = root.Q<Label>("plastic-label");
        metal = root.Q<Label>("metal-label");
    }

    private void Update()
    {
        hp.text = inventory.health.ToString();
        plastic.text = inventory.Plastic.ToString();
        metal.text = inventory.Metal.ToString();
    }
}
