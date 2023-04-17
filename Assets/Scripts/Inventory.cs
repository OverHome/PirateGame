using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> Items = new List<Item>();
    [SerializeField] public UnityEvent OnInventoryChange;
    [SerializeField] public int Size = 4;

    public bool AddItem(Item item)
    {
        if (Items.Count == Size) return false;
        Items.Add(item);
        OnInventoryChange.Invoke();
        return true;
    }
}
