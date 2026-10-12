using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]

public class ItemData : ScriptableObject
{
    public string DisplayName;
    public Sprite Icon;
    public ItemKind Kind;
    public int HealAmount = 25;
    public float Multiplier = 1.5f;
    public float Duration = 10f;


}


public enum ItemKind 
{
    HealthPotion, SpeedPotion, JumpPotion
}