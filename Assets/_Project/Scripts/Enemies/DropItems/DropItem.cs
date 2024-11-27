using UnityEngine;

[CreateAssetMenu(fileName = "DropItem", menuName = "Scriptable Objects/DropItem")]
public class DropItem : ScriptableObject
{
    public string itemName;
    public int dropChance;
    public GameObject itemPrefab;

    public DropItem(string itemName, int dropChance)
    {
        this.itemName = itemName;
        this.dropChance = dropChance;
    }
}