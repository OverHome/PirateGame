using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] public Transform Transform;
    
    public void SetPos()
    {
        var position = Transform.position;
        gameObject.transform.position = new Vector2(position.x, position.y);
    }
    
    public void ChangeVisibl()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr.color.a == 0)
        {
            sr.color = new Color(255, 255, 255, 255);
        }
        else
        {
            sr.color = new Color(255, 255, 255, 0);
        }
    }
}
