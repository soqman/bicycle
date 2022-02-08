using System;
using UnityEngine;

public class CameraController : BaseController
{
    public event Action OnWorldBoundsReachEvent;
    
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;

    private Vector3 position;
    private float WorldBoundsX => GameRuntime.terrain.LastCoordinatesX;

    public override void Init()
    {
        base.Init();
        position = cam.transform.position;
    }
    
    protected override void UpdateWork()
    {
        base.UpdateWork();
        
        FollowTarget();
        if (IsWorldBoundsReached())
        {
            OnWorldBoundsReachEvent?.Invoke();
        }
    }

    private void FollowTarget()
    {
        position.x = target.position.x;
        cam.transform.position = position;
    }
    

    private bool IsWorldBoundsReached()
    {
        return cam.ViewportToWorldPoint(cam.rect.max).x > WorldBoundsX;
    }
}