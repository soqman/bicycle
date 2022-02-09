using System;
using UnityEngine;

public class EngineController : BaseController
{
    [SerializeField] private Rigidbody2D gear;
    [SerializeField] private EngineSettings settings;
    
    protected override void UpdateWork()
    {
        base.UpdateWork();
        
        Accelerate();
        Brake();
    }

    public override void StartWork()
    {
        gear.angularVelocity = 0f;
        gear.velocity = Vector2.zero;
        base.StartWork();
    }

    private void Accelerate()
    {
        if (isStarted && GameRuntime.input.IsPositiveAxisHeld)
        {
            gear.AddTorque(-settings.accelerateSpeed);
        }
    }

    private void Brake()
    {
        if (isStarted && GameRuntime.input.IsNegativeAxisHeld)
        {
            gear.angularDrag = settings.brakeSpeed;
        }
        else
        {
            gear.angularDrag = 0;
        }
    }
}