using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 cursorHotSpot;
    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture,cursorHotSpot,CursorMode.Auto);
    }
}
