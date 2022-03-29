using System.Collections;
using System.Collections.Generic;
using PellesAssets;
using UnityEngine;

public interface IInteractable
{
    void Interact(FPSController player, Inventory inventory);
}
