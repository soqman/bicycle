using UnityEngine;

public class TouchInputController : BaseInputController
{
    private enum ScreenSide
    {
        Left,
        Right
    };

    private ScreenSide screenSide;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetScreenSide(Input.mousePosition);
        }

        HandleTouch();
    }

    private void SetScreenSide(Vector2 position)
    {
        screenSide = position.x <= Screen.width / 2f ? ScreenSide.Left : ScreenSide.Right;
    }

    private void HandleTouch()
    {
        if (!Input.GetMouseButton(0))
        {
            isPositiveAxisHeld = false;
            isNegativeAxisHeld = false;
            
            return;
        }
        
        isPositiveAxisHeld = screenSide == ScreenSide.Left;
        isNegativeAxisHeld = screenSide == ScreenSide.Right;
    }
}