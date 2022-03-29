using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour,IDamaging
{
    private Animator _animator;
    private static readonly int Fire1 = Animator.StringToHash("Fire");

    private FPSInputs _fpsInputs;
    [SerializeField] private Transform camera;
    

    public int Damage { get; set; }
    public bool Active { get; set; }
    public bool firing;
    public bool wait;
    private void Start()
    {
        _fpsInputs = new FPSInputs();
        _fpsInputs.Default.Attack.Enable();
        _fpsInputs.Default.Attack.performed += Fire;
        Damage = 5;
        _animator = GetComponent<Animator>();
    }

    private void Fire(InputAction.CallbackContext callbackContext)
    {
        _animator.SetBool(Fire1,true);
        firing = true;
        Active = true;
        if (Physics.Raycast(camera.position,camera.forward,out RaycastHit hit,4f))
        {
            if (hit.collider.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy)&& !wait)
            {
                enemy.TakeDamage(5);
                wait = true;
            }
        }
    }

    public void StopFiring()
    {
        firing = false;
        Active = false;
        _animator.SetBool(Fire1,false);
        wait = false;
    }
    
}
