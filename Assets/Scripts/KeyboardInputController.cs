using UnityEngine;

public class KeyboardInputController : BaseInputController
{
    private void Update()
    {
        isPositiveAxisHeld = Input.GetButton("Positive");
        isNegativeAxisHeld = Input.GetButton("Negative");
    }
}