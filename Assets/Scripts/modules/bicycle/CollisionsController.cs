using System;
using System.Collections.Generic;
using common;

namespace modules.bicycle
{
    public class CollisionsController : BaseController
    {
        public event Action PlayerHurtEvent;

        private Collision playerHurtCollision = new Collision(Tag.Player, Tag.Obstacle);
    
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
        }

        public void UnregisterCollision(Collision collision)
        {
            collisions.Remove(collision);
        }

        protected override void UpdateWork()
        {
            base.UpdateWork();
            CheckPlayer();
        }

        public override void StartWork()
        {
            collisions.Clear();
            base.StartWork();
        }

        private void CheckPlayer()
        {
            if (!collisions.Contains(playerHurtCollision)) return;
            PlayerHurtEvent?.Invoke();
        }
    }
}