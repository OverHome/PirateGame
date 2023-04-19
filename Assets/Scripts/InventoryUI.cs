using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> _icons = new();
    [SerializeField] private Inventory _inventory;
    private List<InventoryUISlot> _inventoryUISlot;

    void Start()
    {
        _inventoryUISlot = GetComponentsInChildren<InventoryUISlot>().ToListPooled();
        UpdatUI();
    }

    public void UpdatUI()
    {
        for (int i = 0; i < _inventory.Size; i++)
        {
            if (i < _inventory.Items.Count)
            {
                _icons[i].sprite = _inventory.Items[i].Icon;
                _icons[i].color = new Color(255, 255, 255, 1);
            }
            else
            {
                _icons[i].sprite = null;
                _icons[i].color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void Select(int numberOfCount)
    {
        GameData.PlayerIsBusy = false;
        foreach (var slot in _inventoryUISlot)
        {
            if (slot.NumberOfCount == numberOfCount && slot.NumberOfCount < _inventory.Items.Count)
            {
                if (slot.IsSelected)
                {
                    slot.UnSelect();
                }
                else
                {
                    slot.Select();
                    GameData.PlayerIsBusy = true;
                }
            }
            else
            {
                slot.UnSelect();
            }
        }
    }
}
