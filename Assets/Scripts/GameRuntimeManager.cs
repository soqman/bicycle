using System.Collections.Generic;
using UnityEngine;

public class GameRuntimeManager : MonoBehaviour
{
    private readonly List<BaseController> controllers = new List<BaseController>();

    private void Awake()
    {
        controllers.Add(GameRuntime.input = GetComponentInChildren<BaseInputController>(true));
        controllers.Add(GameRuntime.engine = GetComponentInChildren<EngineController>(true));
        controllers.Add(GameRuntime.camera = GetComponentInChildren<CameraController>(true));
        controllers.Add(GameRuntime.terrain = GetComponentInChildren<TerrainController>(true));
    }

    private void Start()
    {
        controllers.ForEach(x => x.Init());
        controllers.ForEach(x => x.StartWork());
    }
}

public static class GameRuntime
{
    public static BaseInputController input;
    public static EngineController engine;
    public static CameraController camera;
    public static TerrainController terrain;
}