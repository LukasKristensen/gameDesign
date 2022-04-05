using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public abstract class Equippable: MonoBehaviour
    {
        public EquippableType type;
        public int teir;
        public abstract void Fire(InputAction.CallbackContext callbackContext);
        public virtual void OnDraw()
        {
            
        }
        public virtual void OnHolster()
        {
            
        }
    }
}