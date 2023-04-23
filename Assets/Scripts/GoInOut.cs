using UnityEngine;
using UnityEngine.EventSystems;

public class GoInOut : MonoBehaviour, IPointerClickHandler, IFeading
{
    private Kapitan _kapitan;
    private bool _wait;
    [SerializeField] private GameObject _original;
    [SerializeField] private GameObject _next;
    [SerializeField] private Fadeing _fadeing;

    private void Start()
    {
        _kapitan = GameObject.Find("kapitan").GetComponent<Kapitan>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_kapitan.PlayerIsBusy)
        {
            _kapitan.SetMoveTo(gameObject.transform.position);
            _wait = true; 
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (_wait)
        {
            _fadeing.FadeIn(this);
            _wait = false;
        }
    }

    public void OnFafeIn()
    {
        _next.SetActive(true);
        _original.SetActive(false);
        _fadeing.FadeOut();
        _kapitan.PlayerIsBusy = false;  
    }
    public void OnFafeOut()
    {
        _kapitan.PlayerIsBusy = false;  
    }
}
