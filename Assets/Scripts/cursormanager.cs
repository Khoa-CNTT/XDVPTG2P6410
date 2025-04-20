using UnityEngine;

public class cursormanager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorshoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hostpot= new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorshoot, hostpot, CursorMode.Auto);
        }
        else if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
        }
        if (Input.GetMouseButton(1))
        {
            Cursor.SetCursor(cursorReload, hostpot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
        }
    }
}
