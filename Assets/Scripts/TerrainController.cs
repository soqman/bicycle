using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class TerrainController : BaseController
{
    [SerializeField] private SpriteShapeController shape;
    [SerializeField] private TerrainSettings settings;

    private int index;
    private int initPointsCount;
    private Vector2 lastCoordinates;
    

    public float LastCoordinatesX => lastCoordinates.x - settings.boundsXOffset;
    
    public override void Init()
    {
        GameRuntime.camera.WorldBoundsReachEvent += OnWorldBoundsReach;
        initPointsCount = shape.spline.GetPointCount();
        Reset();
        base.Init();
    }

    private void OnWorldBoundsReach()
    {
        AddVertex();
    }

    private void AddVertex()
    {
        lastCoordinates = CalculateNextVertex();
        shape.spline.InsertPointAt(index, lastCoordinates);
        index++;
    }

    private Vector3 CalculateNextVertex()
    {
        return new Vector3(lastCoordinates.x + Random.Range(settings.xDeltaMin, settings.xDeltaMax),
            Mathf.Clamp(lastCoordinates.y + Random.Range(settings.yDeltaMin, settings.yDeltaMax),
                settings.terrainHeightMin, settings.terrainHeightMax));
    }

    public void Reset()
    {
        for (var i = index-1; i >= initPointsCount; i--)
        {
            shape.spline.RemovePointAt(i);
        }
        
        index = initPointsCount;
        lastCoordinates = shape.spline.GetPosition(index - 1);
    }
}