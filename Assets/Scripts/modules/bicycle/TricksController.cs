using System;
using System.Collections.Generic;
using System.Linq;
using common;
using managers;
using UnityEngine;

namespace modules.bicycle
{
    public class TricksController : BaseController
    {
        [SerializeField] private List<TrickSettings> tricks = new List<TrickSettings>();
        public event Action TricksUpdatedEvent;
        
        private readonly Dictionary<string, TrickSettings> settingsMap = new Dictionary<string, TrickSettings>();
        private readonly Dictionary<string, Trick> tricksMap = new Dictionary<string, Trick>();

        private HashSet<string> initedTricks = new HashSet<string>();
        private HashSet<string> activeTricks = new HashSet<string>();

        private bool isDirty;

        public ICollection<string> ActiveTricks => activeTricks;

        public override void Init()
        {
            GameRuntime.collisions.CollisionsUpdate += OnCollisionsUpdate;
            tricks.ForEach(x =>
            {
                settingsMap.Add(x.name, x);
                tricksMap.Add(x.name, new Trick(x.name));
            });

            base.Init();
        }
        
        public override void StopWork()
        {
            base.StopWork();
            
            initedTricks.Clear();
            activeTricks.Clear();

            foreach (var item in tricksMap.Values)
            {
                item.initTime = 0f;
            }

            TricksUpdatedEvent?.Invoke();
        }

        private void LateUpdate()
        {
            isDirty = false;
        }

        private void OnCollisionsUpdate()
        {
            var current = GetCurrentSuitableTricksIds();
            CheckForTrickEnd(current);
            foreach (var item in current)
            {
                CheckForTrickInit(item);
            }
        }
        
        protected override void UpdateWork()
        {
            base.UpdateWork();
            initedTricks.ToList().ForEach(CheckForTrickStart);
            
            if(isDirty) TricksUpdatedEvent?.Invoke();
        }

        private void CheckForTrickInit(string id)
        {
            if (activeTricks.Contains(id) || initedTricks.Contains(id)) return;
            
            initedTricks.Add(id);
            tricksMap[id].initTime = 0f;
        }
        
        private void CheckForTrickStart(string id)
        {
            tricksMap[id].initTime += Time.deltaTime;
            if (tricksMap[id].initTime > settingsMap[id].initThreshold)
            {
                initedTricks.Remove(id);
                activeTricks.Add(id);
                
                isDirty = true;
            }
        }

        private void CheckForTrickEnd(ICollection<string> current)
        {
            activeTricks.RemoveWhere(x => !current.Contains(x));
            initedTricks.RemoveWhere(x => !current.Contains(x));
            isDirty = true;
        }
        
        private HashSet<string> GetCurrentSuitableTricksIds()
        {
            var result = new HashSet<string>();
            foreach (var trick in tricks)
            {
                if (GameRuntime.collisions.CheckCollisions(trick.IncludeCollisions, trick.ExcludeCollisions))
                {
                    result.Add(trick.name);
                }
            }

            return result;
        }
    }
}