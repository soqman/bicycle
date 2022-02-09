using System.Collections;
using common;
using managers;
using UnityEngine;

namespace game
{
    public class SessionController : BaseController
    {
        [SerializeField] private float resetDelay;
        [SerializeField] private string playerHurtFxId;
        public override void Init()
        {
            GameRuntime.collisions.PlayerHurtEvent += OnPlayerHurt;
            base.Init();
        }

        private void OnPlayerHurt()
        {
            StartCoroutine(ResetRoutine());
        }

        private IEnumerator ResetRoutine()
        {
            GameRuntime.engine.StopWork();
            GameRuntime.collisions.StopWork();
            GameRuntime.fx.PlayFx(playerHurtFxId);
            yield return new WaitForSeconds(resetDelay);
            GameRuntime.terrain.Reset();
            GameRuntime.bicycle.Reset();
            GameRuntime.collisions.StartWork();
            GameRuntime.engine.StartWork();
        }
    }
}