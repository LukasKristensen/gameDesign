using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour,IDamaging
{
    private Animator _animator;
    private static readonly int Fire1 = Animator.StringToHash("Fire");

    private FPSInputs _fpsInputs;

    public int Damage { get; set; }
    public bool Active { get; set; }
    public bool firing;

    private void Start()
    {
        _fpsInputs = new FPSInputs();
        _fpsInputs.Default.Attack.Enable();
        _fpsInputs.Default.Attack.performed += Fire;
        Damage = 1;
        _animator = GetComponent<Animator>();
    }

    private void Fire(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Firing");
        _animator.SetBool(Fire1,true);
        firing = true;
        Active = true;
    }

    public void StopFiring()
    {
        firing = false;
        Active = false;
        _animator.SetBool(Fire1,false);
    }
    
}
