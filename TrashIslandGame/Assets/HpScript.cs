using System.Collections;
using System.Collections.Generic;
using PellesAssets;
using TMPro;
using UnityEngine;

public class HpScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FPSController plaeyr;
    
    
    void Update()
    {
        text.text = "health: " + plaeyr.health;
    }
}
