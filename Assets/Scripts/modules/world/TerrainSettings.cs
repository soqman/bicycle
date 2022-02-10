using UnityEngine;

namespace modules.world
{
    [CreateAssetMenu(fileName = "TerrainSettings", menuName = "Settings/Terrain")]
    public class TerrainSettings : ScriptableObject
    {
        public float xDeltaMin;
        public float xDeltaMax;
        public float yDeltaMin;
        public float yDeltaMax;

        public float terrainHeightMin;
        public float terrainHeightMax;

        public float boundsXOffset;
    }
}