using System;
using UnityEngine;

public class MoveTriger : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] public Transform GoToPoint;
    [SerializeField] public float Spead;
    
    
    private bool IsUse;
    private Vector2 targetPosition;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        IsUse = false;
        targetPosition = transform.position;
    }
    
    private void Update()
    {
        _animator.SetFloat("MoveX", Math.Abs(transform.position.x - targetPosition.x));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * Spead);
        if (!IsUse)
        {
            if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
            {
                targetPosition = GoToPoint.position;
                gameObject.GetComponent<SpriteRenderer>().flipX = transform.position.x>GoToPoint.position.x;
                IsUse = true;
            }
        }
    }
}
