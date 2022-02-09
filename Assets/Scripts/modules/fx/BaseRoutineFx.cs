using System.Collections;
using UnityEngine;

namespace modules.fx
{
    public abstract class BaseRoutineFx : BaseFx
    {
        private Coroutine coroutine;
        public override void Play()
        {
            if (coroutine != null) StopRoutine();
            coroutine = StartCoroutine(Routine());
        }

        public override void Stop()
        {
            StopRoutine();
        }
    
        private void StopRoutine()
        {
            if (coroutine == null) return;
            StopCoroutine(coroutine);
            coroutine = null;
        }
        protected abstract IEnumerator Routine();
    }
}