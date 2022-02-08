using UnityEngine;

[CreateAssetMenu(fileName = "EngineSettings", menuName = "Settings/Engine")]
public class EngineSettings : ScriptableObject
{
    public float accelerateSpeed;
    public float brakeSpeed;
}