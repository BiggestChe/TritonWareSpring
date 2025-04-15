using UnityEngine;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemBeingDragged;
    private Vector3 startPosition;

    //displacement of a vector value
    private Vector3 offset;
    public Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }


public void OnBeginDrag(PointerEventData eventData)
{
    startPosition = transform.position;
    offset = transform.position - Input.mousePosition;
    transform.SetAsLastSibling(); // bring to front
    Debug.Log("please work");
}


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPosition;
    }
}
