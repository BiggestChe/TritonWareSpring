using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assign the main camera to cam
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Only trigger once per click
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Shoots a raycast at mousePos
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit && hit.transform.CompareTag("Interactable"))
            {
                IClickable clickable = hit.collider.GetComponent<IClickable>();
                clickable?.Click(); // Call Click if IClickable exists
            }
        }
    }
}

