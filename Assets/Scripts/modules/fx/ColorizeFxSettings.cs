using UnityEngine;

namespace modules.fx
{
    [CreateAssetMenu(fileName = "ColorizeFxSettings", menuName = "Settings/ColorizeFx")]
    public class ColorizeFxSettings : ScriptableObject
    {
        public Color target;
        public AnimationCurve curve;
        public float duration;
    }
}