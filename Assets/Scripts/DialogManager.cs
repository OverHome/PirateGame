using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panel;

    public TextMeshProUGUI dialog;

    public string[] message;

    public bool dialogStart = false;

    public int counter = 0;
    void Start()
    {
        message[0] = "hello";
        message[1] = "idi naxui";
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("called");
            dialog.text = "hui";
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerEnter called");
        if (collider.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            dialog.text = message[0];
            dialogStart = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("OnTriggerExit called");
        panel.SetActive(false);

        dialogStart = false;
    }
}
