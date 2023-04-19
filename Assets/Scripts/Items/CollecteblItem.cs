using System;
using UnityEngine;

public class CollecteblItem : MonoBehaviour
{
    [SerializeField] public string ItemName;
    [SerializeField] public Sprite Icon;
    [SerializeField] public int ItemId;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Icon;
    }
}
