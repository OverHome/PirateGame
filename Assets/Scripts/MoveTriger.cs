using UnityEngine;

public class MoveTriger : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] public Transform GoToPoint;
    [SerializeField] public float Spead;
    
    private bool IsUse;
    private Vector2 targetPosition;
    private void Start()
    {
        IsUse = false;
        targetPosition = transform.position;
    }
    
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), Time.deltaTime * Spead);
        if (!IsUse)
        {
            if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
            {
                targetPosition = GoToPoint.position;
                IsUse = true;
            }
        }
    }
}
