using System;
using System.Collections;
using System.Collections.Generic;
using PellesAssets;
using UnityEngine;

public class waterScr : MonoBehaviour
{
    [SerializeField] private float timer;
    
    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.collider.name);
        if (other.gameObject.TryGetComponent(out FPSController fpsController))
        {
            if (timer<0)
            {
                fpsController.TakeDamage(1);
                timer = 1;
            }

            timer -= Time.deltaTime;
        }
    }
}
