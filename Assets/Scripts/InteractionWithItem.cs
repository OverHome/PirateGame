using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionWithItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public int ExpectedItem;
    [SerializeField] public Inventory Inventory;
    [SerializeField] public GameObject GameObjectPosition;
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    private Vector2 Position;

    private void Start()
    {
        var position = GameObjectPosition.transform.position;
        Position = new Vector2(position.x, position.y);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Inventory.SelectedItem != -1)
        {
            Inventory.UseItem(ExpectedItem, Position, TrigerValueName, TrigerValue);
        }
    }
}
