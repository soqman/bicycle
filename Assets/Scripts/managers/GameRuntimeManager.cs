using System.Collections.Generic;
using common;
using game;
using modules.bicycle;
using modules.fx;
using modules.input;
using modules.world;
using UnityEngine;

namespace managers
{
    public class GameRuntimeManager : MonoBehaviour
    {
        private readonly List<BaseController> controllers = new List<BaseController>();

        private void Awake()
        {
            controllers.Add(GameRuntime.input = GetComponentInChildren<BaseInputController>(true));
            controllers.Add(GameRuntime.engine = GetComponentInChildren<EngineController>(true));
            controllers.Add(GameRuntime.camera = GetComponentInChildren<CameraController>(true));
            controllers.Add(GameRuntime.terrain = GetComponentInChildren<TerrainController>(true));
            controllers.Add(GameRuntime.fx = GetComponentInChildren<FxController>(true));
            controllers.Add(GameRuntime.collisions = GetComponentInChildren<CollisionsController>(true));
            controllers.Add(GameRuntime.bicycle = GetComponentInChildren<BicycleController>(true));
            controllers.Add(GameRuntime.session = GetComponentInChildren<SessionController>(true));
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
        public static FxController fx;
        public static CollisionsController collisions;
        public static BicycleController bicycle;
        public static SessionController session;
    }
}