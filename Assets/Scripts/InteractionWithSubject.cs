using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionWithSubject : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] public int ExpectedItem;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
