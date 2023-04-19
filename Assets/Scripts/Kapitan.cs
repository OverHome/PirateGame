using System;
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
    
    [SerializeField] public float Spead = 2f;

    private Animator anim;
    void Start()
    {
        _inventory = GetComponent<Inventory>();
        anim = GetComponent<Animator>();
        targetPosition = new Vector2(transform.position.x, transform.position.y);
        TakeItem = "";
        IsUseItem = false;
    }
        
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            IsMove = true;
        if(Input.GetKeyUp(KeyCode.Mouse0))
            IsMove = false;
        Move();
        if (IsUseItem) UseItem();
        print(GameData.PlayerIsBusy);
    }

    private void Move()
    {
        if(!GameData.PlayerIsBusy && IsMove)
        {
            Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            GameData.PlayerIsBusy = false;
        }
    }

    public void SetUseItem(Vector2 vector2)
    {
        targetPosition = vector2;
        IsUseItem = true;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wal")
        {
            int waste = toRight ? -1 : 1;
            transform.localRotation = Quaternion.Euler(0, 180 * (!toRight ? 0 : 1), 0);
            targetPosition = new Vector2(transform.position.x+0.1f*waste, transform.position.y);
        }
    }

    public void SetTakeItem(CollecteblItem item)
    {
        if (!GameData.PlayerIsBusy)
        {
            TakeItem = item.name;
            GameData.PlayerIsBusy = true; 
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
                GameData.PlayerIsBusy = false;
                if (_inventory.AddItem(item))
                {
                    TagName.gameObject.SetActive(false);
                    Destroy(other.gameObject);    
                }
            }
        }
            
    }
}
