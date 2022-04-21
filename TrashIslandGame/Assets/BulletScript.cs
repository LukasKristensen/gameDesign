using System.Collections;
using System.Collections.Generic;
using PellesAssets;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    
    public Transform target;
    
    
    void Update()
    {
        transform.position += (target.position -transform.position ).normalized * speed * Time.deltaTime;
        if ((target.position -transform.position ).magnitude<0.5)
        {
            target.GetComponent<FPSController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
