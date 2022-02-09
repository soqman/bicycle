using System.Collections.Generic;
using common;
using UnityEngine;

namespace modules.fx
{
    public class FxController : BaseController
    {
        [SerializeField] private GameObject root;
    
        private Dictionary<string, BaseFx> map = new Dictionary<string, BaseFx>();
        private Dictionary<string, BaseFx> activeFxs = new Dictionary<string, BaseFx>();

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
            fx.StopFxEvent += OnStopFx;
        
            fx.Play();
        }
    
        public void StopFxForce(string id)
        {
            if (!activeFxs.TryGetValue(id, out var fx)) return;
            fx.Stop();
        }

        private void OnStopFx(string id)
        {
            activeFxs.Remove(id);
        }
    }
}