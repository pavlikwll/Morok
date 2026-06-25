using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Morok/Inventory/Item")]
public class ItemDefinition : ScriptableObject
{
    public string id;
    public int stackingCap;
    
    public Sprite sprite;
    public string displayName;

    [TextArea(3,10)]
    public string description;
}