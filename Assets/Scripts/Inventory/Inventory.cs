using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int Capacity = 6;
    readonly List<ItemStack> Items = new();
    int selected = -1;
    public int Count => Items.Count;
    public int Selected => selected;
    public ItemData Active => selected <= 0 ? Items[selected].Item : null; // om inte noll hämta item, eller null
    public ItemData Get(int index) => Items[index].Item;
    public int GetAmount(int index) => Items[index].Amount;
    public event Action Changed;

    public bool TryAdd(ItemData item, int amount = 1)
    {
        if (amount <= 0 || !CanAdd(item))
            return false;

        ItemStack stack = Items.Find(x => x.Item == item);

        if(stack != null)
            stack.Amount = amount;
        else 
        {
            Items.Add(new ItemStack(amount, item));

            if(selected < 0)
                selected = 0;
        }
        Changed?.Invoke();
        return true;

    }

    public bool CanAdd(ItemData item) 
    {
        return item != null && (Items.Exists(x => x.Item == item)
            || Count < Capacity);
    }

    public void Select(int index) 
    {
        if (index < 0 || index >= Count || index == selected)
            return;

        selected = index;
        Changed?.Invoke();
    }

    public void SelectNext(int step) 
    {
        if (Count == 0)
            return;

        Select((selected + step + Count) % Count); //(4+4 = 8) % Count, om count är 6 går vi till inventory slot 2, tro ja
    }

    public void ConsumeSelected() 
    {
        if (selected < 0)
            return;

        Items[selected].Amount--;

        if (Items[selected].Amount == 0) 
        {
            Items.RemoveAt(selected);
            selected = Mathf.Min(selected, Count - 1);
        }

        Changed?.Invoke();
    }
}
