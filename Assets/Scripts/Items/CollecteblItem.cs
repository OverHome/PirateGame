using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollecteblItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] public Item item;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Icon;
        item.IsTack = false;
    }
    
}
