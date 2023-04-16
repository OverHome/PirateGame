using UnityEngine;

[CreateAssetMenu]
public class Item : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public Sprite Icon;
    public bool IsTack;
}
