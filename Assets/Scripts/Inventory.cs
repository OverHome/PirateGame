using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<CollecteblItem> Items = new();
    [SerializeField] public InventoryUI InventoryUI;
    [SerializeField] public int Size = 4;
    private Canvas _canvas;
    private Kapitan _kapitan;
    public int SelectedItem;

    private void Start()
    {
        _canvas = InventoryUI.GetComponentInParent<Canvas>();
        _kapitan = GetComponent<Kapitan>();
        SelectedItem = -1;
    }

    public bool AddItem(CollecteblItem item)
    {
        if (Items.Count == Size) return false;
        Items.Add(item);
        InventoryUI.UpdatUI();
        return true;
    }

    public void UseItem(int expectedItem, Vector2 position, string TrigerValueName, int TrigerValue)
    {
        if (expectedItem == Items[SelectedItem].ItemId)
        {
            _kapitan.SetUseItem(position, TrigerValueName, TrigerValue);
        }
        else
        {
            UnSelect();
        }
    }

    public void DelUsedItem()
    {
        Items.RemoveAt(SelectedItem);
        UnSelect();
        InventoryUI.UpdatUI();
    }

    public void UnSelect()
    {
        _kapitan.ItemSelected = false;
        InventoryUI.Select(SelectedItem);
    }

    public void SetSelectedItem(int index)
    {
        if (index != -1)
        {
            _kapitan.PlayerIsBusy = true;
        }
        else
        {
            _kapitan.PlayerIsBusy = false;
        }
        SelectedItem = index;
    }

    public void Hide()
    { 
        _canvas.gameObject.SetActive(false);
    }
    
    public void Show()
    {
        _canvas.gameObject.SetActive(true);
    }
}
