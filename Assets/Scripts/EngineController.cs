using UnityEngine;

public class EngineController : BaseController
{
    [SerializeField] private Rigidbody2D gear;
    [SerializeField] private EngineSettings settings;

    private float accelerate;
    private float brake;

    private float accelerateTime;
    private float brakeTime;

    protected override void UpdateWork()
    {
        base.UpdateWork();
        
        Accelerate();
        Brake();
    }

    private void Accelerate()
    {
        if (GameRuntime.input.IsPositiveAxisHeld)
        {
            gear.AddTorque(-settings.accelerateSpeed);
        }
    }

    private void Brake()
    {
        if (GameRuntime.input.IsNegativeAxisHeld)
        {
            gear.angularDrag = settings.brakeSpeed;
        }
        else
        {
            gear.angularDrag = 0;
        }
    }
}