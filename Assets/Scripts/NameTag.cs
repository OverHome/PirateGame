using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    private Vector2 resolution;
    
    private Vector2 resolutionInWorldUnits = new Vector2(17.6f, 10);

    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        print(Input.mousePosition);
        transform.position = Input.mousePosition/resolution*resolutionInWorldUnits;
    }

    public void UpdateTextTag(CollecteblItem item)
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
    }
}
