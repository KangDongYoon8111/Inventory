using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Item item;
    public Image itemIcon;

    public bool isShopMode;
    public bool isSell = false;
    public GameObject chkSell;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(item != null)
        {
            if (!isShopMode)
            {
                bool isUse = item.Use();
                if (isUse)
                {
                    Inventory.instance.RemoveItem(slotNum);
                }
            }
            else
            {
                isSell = true;
                chkSell.SetActive(isSell);
            }
        }
    }

    public void SellItem()
    {
        if (isSell)
        {
            ItemDatabase.instance.money += item.itemCost;
            Inventory.instance.RemoveItem(slotNum);
            isSell = false;
            chkSell.SetActive(isSell);
        }
    }

    private void OnDisable()
    {
        isSell = false;
        chkSell.SetActive(isSell);
    }
}
