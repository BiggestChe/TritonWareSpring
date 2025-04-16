using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public Texture2D cursor; // Default cursor sprite
    public Texture2D cursor_down; // Cursor sprite when mouse button is pressed

    // Start is called before the first frame update
    void Start()

    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        // Change sprite based on mouse button state
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursor_down, Vector2.zero, CursorMode.Auto);
        }
        else
        {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);

        }
    }
}
