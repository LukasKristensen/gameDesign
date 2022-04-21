using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public abstract class Equippable: MonoBehaviour
    {
        public EquippableType type;
        public int teir;
        
        public virtual void OnDraw()
        {
            
        }
        public virtual void OnHolster()
        {
            
        }
    }
}