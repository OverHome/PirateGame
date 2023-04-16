using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Kapitan : MonoBehaviour
{
    public Vector2 targetPosition;
    void Start() {
    }
        
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localRotation = Quaternion.Euler(0, 180 * (targetPosition.x > transform.position.x?1:0), 0);
        }
 
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * 5);
    }
    
}
