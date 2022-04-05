using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using PellesAssets;
using TMPro;
using UnityEngine;

public class ResourceToTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Inventory inventory;
    
    void Update()
    {
        text.text = "Metal :"+inventory.Metal +"\n Plastic :" + inventory.Plastic  ;
    }
}
