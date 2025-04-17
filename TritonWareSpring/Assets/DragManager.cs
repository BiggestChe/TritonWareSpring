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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Bowl"))
        {
            switch(itemBeingDragged.name)
            {
                case "Egg": game
            }
        
            Debug.Log("Dropped on the bowl!");
            Destroy(gameObject); // or SetActive(false), or snap into place
            return;
        }

        // Not dropped on bowl — return to original position
        transform.position = startPosition;
    }
}
