using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemBeingDragged;
    public GameObject cookingSlider; 
    public GameObject knob; 
    private Vector3 startPosition;
    //displacement of a vector value
    private Vector3 offset;
    public Canvas canvas;

    //panel for minigame 

    public GameObject MiniGame;
    public GameObject KitchenObjects;
    private Vector3 doughPosition = new Vector2(-254.7f, -155.4f); // note: Vector2

    public GameManager gameManager;

    public AudioManager audioManager;


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
        //following the mouse cursor, project a raycast that hits with the bowl area
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Bowl"))
        {
            //switch statement for handling of different ingredients
            switch(itemBeingDragged.tag)
            {
                //case for all, use ingredient from basket, while also destroying game object
                case "Egg": 
                gameManager.UseIngredient(GameManager.IngredientType.Egg);
                gameManager.blender_eggs += 1;
                Debug.Log(gameManager.blender_eggs + "eggs");
                break;

                case "Wheat":
                gameManager.UseIngredient(GameManager.IngredientType.Wheat);
                gameManager.blender_wheat += 1;
                Debug.Log(gameManager.blender_wheat + "wheat");
                break;

                case "Milk":
                gameManager.UseIngredient(GameManager.IngredientType.Milk);
                gameManager.blender_milk += 1;
                Debug.Log(gameManager.blender_wheat + "wheat");
                break;
            }
        
            audioManager.Play("Pop2");
            Debug.Log("Dropped in bowl!");
            Destroy(gameObject); // or SetActive(false), or snap into place
            return;
        }

        if(hit.collider != null && hit.collider.CompareTag("Oven") && itemBeingDragged.tag == "Dough" && gameManager.hasDough == true)
        {
            //I'll need to enable knob first so that slider can use the instance of knob
            MiniGame.SetActive(true);
            cookingSlider.SetActive(true);
            knob.SetActive(true);
            
            CookingSlider.sliderInstance.Bake();

            KitchenObjects.SetActive(false);

            canvas.enabled = false;

            gameManager.hasDough = false; 

            Debug.Log("Dropped in bowl!");
            itemBeingDragged.GetComponent<RectTransform>().anchoredPosition = doughPosition;

            gameObject.SetActive(false); 
// or SetActive(false), or snap into place
            return;
        }

        // Not dropped on bowl — return to original position
        transform.position = startPosition;
    }

    
}
