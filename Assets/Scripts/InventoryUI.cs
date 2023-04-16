using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> Icons = new List<Image>();

    public void UpdatUI(Inventory inventory)
    {
       for (int i = 0; i < inventory.Items.Count; i++)
       {
           Icons[i].sprite = inventory.Items[i].Icon;
           Icons[i].color = new Color(255, 255, 255, 1);
       }
    }
}
