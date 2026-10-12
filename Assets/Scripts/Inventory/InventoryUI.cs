using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory PlayerInventory;
    public InventorySlot[] slots;

    void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
            slots[i].Bind(i, PlayerInventory);
    }

    private void OnEnable()
    {
        PlayerInventory.Changed += Refresh;
        Refresh();
    }

    private void Refresh()
    {
        for(int i = 0; i < slots.Length; i++) 
        {
            slots[i].Render(i < PlayerInventory.Count ? PlayerInventory.Get(i) : null, // itemdata eller null
                i < PlayerInventory.Count ? PlayerInventory.GetAmount(i) : 0, //amount eller 0
                i == PlayerInventory.Selected, i + 1); // ger nummer för vilket slot vi tittar på
        }
    }

    private void OnDisable()
    {
        if(PlayerInventory != null)
            PlayerInventory.Changed -= Refresh;
    }
}
