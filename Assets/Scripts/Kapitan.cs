using System;
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

    private Animator anim;
    void Start()
    {
        _inventory = GetComponent<Inventory>();
        anim = GetComponent<Animator>();
        targetPosition = new Vector2(transform.position.x, transform.position.y);
        TakeItem = "";
    }
        
    void Update() {
        if(TakeItem=="" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (getMousePosition.y < 8.5f)
            {
                targetPosition = getMousePosition;
                toRight = targetPosition.x > transform.position.x;
                transform.localRotation = Quaternion.Euler(0, 180 * (toRight ? 0 : 1), 0);
            }
        }
        //anim.SetFloat("MoveX", Math.Abs(transform.position.x - targetPosition.x));
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(targetPosition.x,MainCamera.transform.position.y, MainCamera.transform.position.z), Time.deltaTime * 2.5f);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * 2.5f);
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wal"))
        {
            int waste = toRight ? -1 : 1;
            transform.localRotation = Quaternion.Euler(0, 180 * (!toRight ? 0 : 1), 0);
            targetPosition = new Vector2(transform.position.x+0.1f*waste, transform.position.y);
        }
    }

    public void SetTakeItem(CollecteblItem item)
    {
        TakeItem = item.name;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            CollecteblItem item = other.GetComponent<CollecteblItem>();
            if (TakeItem==item.name)
            {
                TakeItem = "";
                if (_inventory.AddItem(item.item))
                {
                    TagName.gameObject.SetActive(false);
                    Destroy(other.gameObject);    
                }
            }
        }
            
    }

    public void t()
    {
        print("dsfsfsfs");
    }
}
