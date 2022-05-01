using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Equipment, Consumables, Etc }

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public int itemCost;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect effect in efts)
        {
            isUsed = effect.ExecuteRole();
        }
        return isUsed;
    }
}
