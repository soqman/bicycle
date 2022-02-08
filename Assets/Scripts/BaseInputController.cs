using UnityEngine;

public class BaseInputController : MonoBehaviour
{
    protected bool isPositiveAxisHeld;
    protected bool isNegativeAxisHeld;

    public bool IsPositiveAxisHeld => isPositiveAxisHeld;
    public bool IsNegativeAxisHeld => isNegativeAxisHeld;
}