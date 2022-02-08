using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class TerrainController : BaseController
{
    [SerializeField] private SpriteShapeController shape;
    [SerializeField] private TerrainSettings settings;

    private int index;
    private Vector2 lastCoordinates;

    public float LastCoordinatesX => lastCoordinates.x - settings.boundsXOffset;

    private void Awake()
    {
        index = shape.spline.GetPointCount();
        lastCoordinates = shape.spline.GetPosition(index - 1);
    }

    public override void Init()
    {
        GameRuntime.camera.OnWorldBoundsReachEvent += OnWorldBoundsReach;
        base.Init();
    }

    private void OnWorldBoundsReach()
    {
        AddVertex();
    }

    private void AddVertex()
    {
        var position = CalculateNextVertex();
        shape.spline.InsertPointAt(index, position);
        lastCoordinates = position;
        index++;
    }

    private Vector3 CalculateNextVertex()
    {
        return new Vector3(lastCoordinates.x + Random.Range(settings.xDeltaMin, settings.xDeltaMax),
            Mathf.Clamp(lastCoordinates.y + Random.Range(settings.yDeltaMin, settings.yDeltaMax),
                settings.terrainHeightMin, settings.terrainHeightMax));
    }
}