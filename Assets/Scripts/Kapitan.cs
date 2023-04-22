using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Kapitan : MonoBehaviour
{
    private Vector2 targetPosition;
    private bool toRight;
    public String TakeItem;
    private Inventory _inventory;
    public Camera MainCamera;
    public Canvas TagName;
    private bool IsMove;
    private bool IsUseItem;
    public bool PlayerIsBusy;
    public bool ItemSelected;
    
    [SerializeField] public float Spead = 2f;
    [SerializeField] public TextDialog TextDialog;

    private Animator anim;
    void Start()
    {
        
        _inventory = GetComponent<Inventory>();
        anim = GetComponent<Animator>();
        targetPosition = new Vector2(transform.position.x, transform.position.y);
        TakeItem = "";
        IsUseItem = false;
        ItemSelected = false;
    }
        
    void Update() {
        Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.Mouse0))
            IsMove = true;
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsMove = false;
            if (_inventory.SelectedItem != -1 && ItemSelected && !IsUseItem)
            {
                ItemSelected = false;
                _inventory.UnSelect();
            }
            if (_inventory.SelectedItem == -1) ItemSelected = false;

            if (getMousePosition.y > 3.5f && _inventory.SelectedItem != -1)
            {
                ItemSelected = true;
            }
            
        }
            
        Move(getMousePosition);
        if (IsUseItem) UseItem();
    }

    private void Move(Vector2 getMousePosition)
    {
        if(!PlayerIsBusy && IsMove)
        {
            if (getMousePosition.y < 3.5f && Math.Abs(getMousePosition.x - transform.position.x)>0.1)
            {
                targetPosition = getMousePosition;
                toRight = targetPosition.x > transform.position.x;
                transform.localRotation = Quaternion.Euler(0, 180 * (toRight ? 0 : 1), 0);
            }
        }
        anim.SetFloat("MoveX", Math.Abs(transform.position.x - targetPosition.x));
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(targetPosition.x,MainCamera.transform.position.y, MainCamera.transform.position.z), Time.deltaTime * Spead);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * Spead);
    }

    public void UseItem()
    {
        if (targetPosition.x == transform.position.x)
        {
            _inventory.DelUsedItem();
            IsUseItem = false;
            PlayerIsBusy = false;
        }
    }

    public void SetUseItem(Vector2 vector2)
    {
        targetPosition = vector2;
        IsUseItem = true;
    }
    
    public void SetMoveTo(Vector2 vector2)
    {
        targetPosition = vector2;
        PlayerIsBusy = true;
    }
    
    public void StartDialog(Sprite avatar, string name, string tagName, List<TextAsset> dialogs)
    {
        PlayerIsBusy = true;
        targetPosition = gameObject.transform.position;
        _inventory.Hide();
        TextDialog.Show();
        TextDialog.GetStart(avatar, name, tagName, dialogs);
    }
    
    public void EndDialog()
    {
        _inventory.Show();
        TextDialog.Hide();
        PlayerIsBusy = false;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            PlayerIsBusy = true;
            int waste = toRight ? -1 : 1;
            transform.localRotation = Quaternion.Euler(0, 180 * (!toRight ? 0 : 1), 0);
            targetPosition = new Vector2(transform.position.x+0.1f*waste, transform.position.y);
            
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            PlayerIsBusy = false;
            IsMove = false;
        }
    }

    public void SetTakeItem(CollecteblItem item)
    {
        if (!PlayerIsBusy)
        {
            TakeItem = item.name;
            PlayerIsBusy = true; 
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            CollecteblItem item = other.GetComponent<CollecteblItem>();
            if (TakeItem==item.name)
            {
                TakeItem = "";
                PlayerIsBusy = false;
                if (_inventory.AddItem(item))
                {
                    TagName.gameObject.SetActive(false);
                    Destroy(other.gameObject);    
                }
            }
        }
            
    }
}
