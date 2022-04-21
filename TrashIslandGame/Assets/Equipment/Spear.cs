using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Equipment
{
    public class Spear : Equippable
    {
        private Animator _animator;
        private static readonly int Fire1 = Animator.StringToHash("Fire");
        private Transform playerCamera;
        public bool firing;
        public bool wait;
        [SerializeField] private int damage;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            if (playerCamera == null)
            {
                playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }
        }
        
        public void Fire()
        {
            _animator.SetBool(Fire1,true);
            firing = true;
            if (Physics.Raycast(playerCamera.position,playerCamera.forward,out RaycastHit hit,4f))
            {
                if (hit.collider.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy)&& !wait)
                {
                    enemy.TakeDamage(damage);
                    wait = true;
                }
            }
        }
        
        public void StopFiring()
        {
            firing = false;
            _animator.SetBool(Fire1,false);
            wait = false;
        }   
    }
}
