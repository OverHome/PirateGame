using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    private Vector2 resolution, resolutionInWorldUnits = new Vector2(17.6f, 10);
    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        transform.position = Input.mousePosition/resolution*resolutionInWorldUnits;
    }

    public void UpdateTextTag(CollecteblItem item)
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
    }
}
