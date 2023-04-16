using System;
using UnityEngine;

public class Kapitan : MonoBehaviour
{
    private Vector2 targetPosition;
    private bool toRight;
    public bool TakeItem;
    private Inventory _inventory;
    
    void Start()
    {
        _inventory = gameObject.GetComponent<Inventory>();
        targetPosition = new Vector2(transform.position.x, transform.position.y);
        TakeItem = false;
    }
        
    void Update() {
        if(!TakeItem && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = getMousePosition;
            toRight = targetPosition.x > transform.position.x;
            transform.localRotation = Quaternion.Euler(0, 180 * (toRight ? 1 : 0), 0);
            
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wal")
        {
            int waste = toRight ? -1 : 1;
            transform.localRotation = Quaternion.Euler(0, 180 * (!toRight ? 1 : 0), 0);
            targetPosition = new Vector2(transform.position.x+0.1f*waste, transform.position.y);
        }
    }

    public void SetTakeItem()
    {
        TakeItem = true;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            Item item = other.GetComponent<CollecteblItem>().item;
            if (TakeItem)
            {
                TakeItem = false;
                _inventory.AddItem(item);
                Destroy(other.gameObject);
            }
        }
            
    }
}
