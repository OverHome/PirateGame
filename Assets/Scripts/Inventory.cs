using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> Items = new List<Item>();
    [SerializeField] public UnityEvent OnInventoryChange;

    public void AddItem(Item item)
    {
        Items.Add(item);
        OnInventoryChange.Invoke();
    }
}
