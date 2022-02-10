using System.Collections.Generic;
using System.Linq;
using common;
using UnityEngine;

namespace modules.fx
{
    public class FxController : BaseController
    {
        [SerializeField] private GameObject root;

        private Dictionary<string, BaseFx> map = new Dictionary<string, BaseFx>();
        private Dictionary<string, BaseFx> activeFxs = new Dictionary<string, BaseFx>();

        public bool TryGetFx(string id, out BaseFx fx) => map.TryGetValue(id, out fx);

        public override void Init()
        {
            base.Init();

            foreach (var item in root.GetComponentsInChildren<BaseFx>())
            {
                map.Add(item.Id, item);
            }
        }

        public void PlayFx(string id)
        {
            if (activeFxs.ContainsKey(id) || !map.TryGetValue(id, out var fx)) return;

            activeFxs[id] = fx;
            fx.StopFxEvent += OnAutoStopFx;

            fx.Play();
        }

        public override void StopWork()
        {
            foreach (var item in activeFxs.Keys.ToList())
            {
                StopFx(item);
            }

            base.StopWork();
        }

        public void StopFx(string id)
        {
            if (!activeFxs.TryGetValue(id, out var fx)) return;

            fx.Stop();
            activeFxs.Remove(fx.Id);
        }

        private void OnAutoStopFx(string id)
        {
            activeFxs.Remove(id);
        }
    }
}