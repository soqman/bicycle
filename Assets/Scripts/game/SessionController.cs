using System.Collections;
using System.Collections.Generic;
using common;
using managers;
using modules.bicycle;
using modules.collisions;
using UnityEngine;
using Collision = modules.collisions.Collision;

namespace game
{
    public class SessionController : BaseController
    {
        [SerializeField] private float resetDelay;
        [SerializeField] private string playerHurtFxId;

        private readonly Collision gameResetCollision =
            new Collision(CollisionsController.Tag.Player, CollisionsController.Tag.Obstacle);

        public override void Init()
        {
            GameRuntime.collisions.CollisionsUpdate += OnCollisionsUpdate;
            base.Init();
        }

        private void OnCollisionsUpdate()
        {
            if (!GameRuntime.collisions.CheckCollision(gameResetCollision)) return;
            StartCoroutine(ResetRoutine());
        }

        private IEnumerator ResetRoutine()
        {
            GameRuntime.engine.StopWork();
            GameRuntime.collisions.StopWork();
            GameRuntime.fx.PlayFx(playerHurtFxId);
            GameRuntime.tricks.StopWork();
            yield return new WaitForSeconds(resetDelay);
            GameRuntime.terrain.Reset();
            GameRuntime.bicycle.Reset();
            GameRuntime.collisions.StartWork();
            GameRuntime.engine.StartWork();
            GameRuntime.tricks.StartWork();
        }
    }
}