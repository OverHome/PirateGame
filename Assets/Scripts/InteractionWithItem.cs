using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionWithItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public int ExpectedItem;
    [SerializeField] public Inventory Inventory;
    [SerializeField] public GameObject GameObjectPosition = null;
    [SerializeField] public Vector2 Position;

    private void Start()
    {
        Position = new Vector2(GameObjectPosition.transform.position.x, GameObjectPosition.transform.position.y);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Inventory.SelectedItem != -1)
        {
            Inventory.UseItem(ExpectedItem, Position);
        }
    }
}
