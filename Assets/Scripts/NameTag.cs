using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    private Vector2 MousePos;
    
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(MousePos.x, MousePos.y);
    }

    public void UpdateTextTag(CollecteblItem item)
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
    }
}
