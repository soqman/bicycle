using System;
using UnityEngine;

namespace modules.fx
{
    public abstract class BaseFx : MonoBehaviour
    {
        public virtual string Id => gameObject.name;
    
        public event Action<string> StopFxEvent;
        public abstract void Play();
        public abstract void Stop();

        protected void TriggerStopEvent()
        {
            StopFxEvent?.Invoke(Id);
        }
    }
}