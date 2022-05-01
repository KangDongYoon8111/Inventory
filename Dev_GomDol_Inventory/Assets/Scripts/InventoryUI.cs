using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    Inventory inven;

    private void Awake()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
    }

    private void Start()
    {
        inven = Inventory.instance;
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += ReDrawSlotUI;

        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotNum = i;

            if (i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    private void ReDrawSlotUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!activeInventory ? true : false);
            activeInventory = !activeInventory ? true : false;
        }
    }
}
