using UnityEngine;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemBeingDragged;
    private Vector3 startPosition;
    //displacement of a vector value
    private Vector3 offset;
    public Canvas canvas;

    public GameManager gameManager;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }


public void OnBeginDrag(PointerEventData eventData)
{
    itemBeingDragged = gameObject;
    Debug.Log(itemBeingDragged.tag);
    Debug.Log(itemBeingDragged.name);
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
            switch(itemBeingDragged.tag)
            {
                case "Egg": 
                gameManager.blender_eggs += 1;
                Debug.Log(gameManager.blender_eggs + "eggs");
                break;

                case "Wheat":
                gameManager.blender_wheat += 1;
                Debug.Log(gameManager.blender_wheat + "wheat");
                break;

                case "Milk":
                gameManager.blender_milk += 1;
                Debug.Log(gameManager.blender_wheat + "wheat");
                break;
            }
        
            Debug.Log("Dropped on the bowl!");
            Destroy(gameObject); // or SetActive(false), or snap into place
            return;
        }

        // Not dropped on bowl — return to original position
        transform.position = startPosition;
    }
}
