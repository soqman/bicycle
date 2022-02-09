using UnityEngine;

[CreateAssetMenu(fileName = "TrickSettings", menuName = "Settings/Trick")]
public class TrickSettings : ScriptableObject
{
    public CollisionsController.Tag hasContactWithTerrain;
    public CollisionsController.Tag hasNotContactWithTerrain;
    public float initTime;
    public float thresholdTime;
}