using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUISlot : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] public Image StrokePanel;
    private InventoryUI _inventoryUI;
    [SerializeField] public int NumberOfCount;
    public bool IsSelected;

    private void Start()
    {
        IsSelected = false;
        _inventoryUI = GetComponentInParent<InventoryUI>();
        StrokePanel.color = new Color(255, 255, 255, 0);
    }

    public void Select()
    {
        IsSelected = true;
        StrokePanel.color = new Color(255, 255, 255, 1);
    }

    public void UnSelect()
    {
        IsSelected = false;
        StrokePanel.color = new Color(255, 255, 255, 0);
    }

    public void OnPointerDown (PointerEventData eventData) 
    {
        _inventoryUI.Select(NumberOfCount);
    }
}
