using System.Collections;
using UnityEngine;

namespace modules.fx
{
    public class ColorizeFx : BaseRoutineFx
    {
        [SerializeField] private SpriteRenderer renderer;
        [SerializeField] private ColorizeFxSettings settings;
        public override string Id => settings.name;

        private Color initColor;

        private void Awake()
        {
            initColor = renderer.color;
        }

        protected override IEnumerator Routine()
        {
            var elapsed = 0f;

            while (elapsed < settings.duration)
            {
                elapsed += Time.deltaTime;
                var progress = settings.curve.Evaluate(elapsed / settings.duration);
                renderer.color = Color.LerpUnclamped(initColor, settings.target, progress);

                yield return null;
            }

            TriggerStopEvent();
        }
    }
}