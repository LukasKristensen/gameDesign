using UnityEngine;

namespace Core
{
    public abstract class Killable : MonoBehaviour
    {
        public int health = 3;
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}