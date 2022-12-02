using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D handCursor;
    public static MouseControl instance;

    // To be honest.. I have no idea what this stuff does
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Sets the mouse cursor to the default cursor
    public void Start()
    {
        Default();
    }

    // This method is used to set the cursor to a default image
    public void Default()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    // This method is used to set the cursor to a clickable image when hovered over one
    public void Clickable()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }
}
