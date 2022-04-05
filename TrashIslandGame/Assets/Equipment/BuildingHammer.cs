using Core;
using UnityEngine.InputSystem;

namespace Equipment
{
    public class BuildingHammer : Equippable
    {

        private ConstructionManager ConstructionManager;
        private void Start()
        {
            ConstructionManager = FindObjectOfType<ConstructionManager>();
        }

        public override void Fire(InputAction.CallbackContext callbackContext)
        {
        
        }

        public override void OnDraw()
        {
            ConstructionManager?.RevealMenus();
        }

        public override void OnHolster()
        {
            ConstructionManager?.HideMenus();
        }
    }
}
