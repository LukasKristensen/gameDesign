using InventoryItems;
using UnityEngine;


[CreateAssetMenu(fileName = "GameVariables", menuName = "ScriptableObjects/GameVariables", order = 1)]
public class GameVariables : ScriptableObject
{
    public int playerStartingHP;
    public int fruitHeal;
    public float BaseTrashSpawnRate;
    public float MaxTrashSpawnRate;
    public float TimeToMaxSpawnRate;
    public float FloatingTrashSpeed;
    public int WalkerHP;
    public int WalkerDamage;
    public int ShooterHp;
    public int ShooterDamage;
}
