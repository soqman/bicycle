using UnityEngine;

namespace modules.input
{
    public class KeyboardInputController : BaseInputController
    {
        private void Update()
        {
            isPositiveAxisHeld = Input.GetButton("Positive");
            isNegativeAxisHeld = Input.GetButton("Negative");
        }
    }
}