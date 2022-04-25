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
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _parentAudioSource;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            if (playerCamera == null)
            {
                playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }

            _parentAudioSource =  GetComponentInParent<SpearController>().audioSource;
        }
        
        public void Fire()
        {
            _animator.SetBool(Fire1,true);
            firing = true;
            
        }

        public void PlaySound()
        {
            _parentAudioSource.Play();
        }

        public void Hit()
        {
            if (Physics.Raycast(playerCamera.position,playerCamera.forward,out RaycastHit hit,4f))
            {
                if (hit.collider.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy)&& !wait)
                {
                    enemy.TakeDamage(damage);
                    wait = true;
                    _audioSource.Play();
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
