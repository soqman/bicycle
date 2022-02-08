public class BaseInputController : BaseController
{
    protected bool isPositiveAxisHeld;
    protected bool isNegativeAxisHeld;

    public bool IsPositiveAxisHeld => isPositiveAxisHeld;
    public bool IsNegativeAxisHeld => isNegativeAxisHeld;
}