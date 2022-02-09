using System;
using System.Collections.Generic;
using System.Linq;
using common;

namespace modules.collisions
{
    public class CollisionsController : BaseController
    {
        public event Action CollisionsUpdate;

        public enum Tag
        {
            Player,
            WheelFront,
            WheelBack,
            Obstacle
        }

        private readonly List<Collision> collisions = new List<Collision>();

        public void RegisterCollision(Collision collision)
        {
            collisions.Add(collision);
            CollisionsUpdate?.Invoke();
        }

        public void UnregisterCollision(Collision collision)
        {
            collisions.Remove(collision);
            CollisionsUpdate?.Invoke();
        }

        public override void StartWork()
        {
            collisions.Clear();
            base.StartWork();
        }

        public bool CheckCollisions(List<Collision> includeCollisions, List<Collision> excludeCollisions = null)
        {
            if (includeCollisions != null && !includeCollisions.All(x => collisions.Contains(x))) return false;
            if (excludeCollisions != null && excludeCollisions.Any(x => collisions.Contains(x))) return false;

            return true;
        }

        public bool CheckCollision(Collision collision)
        {
            return collisions.Contains(collision);
        }
    }
}