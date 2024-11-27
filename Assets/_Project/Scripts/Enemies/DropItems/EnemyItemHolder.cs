using System.Collections.Generic;
using UnityEngine;

public class EnemyItemHolder : MonoBehaviour
{
    [SerializeField] private GameObject droppedItemPrefab;
    [SerializeField] private List<DropItem> itemList = new List<DropItem>();

    // Reference Scriptable Object
    DropItem GetDroppedItem()
    {
        int rollRandomNumber = Random.Range(1, 101); // 1 (inclusive) - 100 (101 is exclusive)
        List<DropItem> possibleItems = new List<DropItem>();
        foreach (DropItem item in itemList)
        {
            // Check if the rolled number is less than the dropChance from the items
            if (rollRandomNumber <= item.dropChance)
            {
                // If the rolled number is less than the dropchance, add it to the new list
                possibleItems.Add(item);
            }
        }
        // Only one item will be dropped
        if (possibleItems.Count > 0)
        {
            DropItem dropItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return dropItem;
        }
        // Return null if the chance is higher than all of the possible items
        return null;
    }

    public void DropItemOnDeath(Vector3 dropPosition)
    {
        // Get the logic from above
        DropItem item = GetDroppedItem();

        // Check if the item does not return null, then instantiate it when this function is called
        if (item != null)
        {
            GameObject itemGameObject = Instantiate(droppedItemPrefab, dropPosition, Quaternion.identity);
            // Get the item prefab and spawn it at the same position
            GameObject modelPrefab = item.itemPrefab;
            Instantiate(modelPrefab, dropPosition, Quaternion.identity, itemGameObject.transform);
        }
    }
}