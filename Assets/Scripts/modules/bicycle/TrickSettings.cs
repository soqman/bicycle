using System.Collections.Generic;
using System.Linq;
using modules.collisions;
using UnityEngine;
using Collision = modules.collisions.Collision;

namespace modules.bicycle
{
    [CreateAssetMenu(fileName = "TrickSettings", menuName = "Settings/Trick")]
    public class TrickSettings : ScriptableObject
    {
        public List<CollisionsController.Tag> hasContactWithTerrain;
        public List<CollisionsController.Tag> hasNotContactWithTerrain;
        public float initThreshold;
        public float pauseThreshold;

        public List<Collision> IncludeCollisions => hasContactWithTerrain.Select(item => new Collision(item, CollisionsController.Tag.Obstacle)).ToList();
        public List<Collision> ExcludeCollisions => hasNotContactWithTerrain.Select(item => new Collision(item, CollisionsController.Tag.Obstacle)).ToList();
    }
}