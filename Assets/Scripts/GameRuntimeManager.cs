using UnityEngine;

public class GameRuntimeManager : MonoBehaviour
{
    private void Awake()
    {
        GameRuntime.input = GetComponentInChildren<BaseInputController>(true);
        GameRuntime.engine = GetComponentInChildren<EngineController>(true);
    }
}
    
public static class GameRuntime
{
    public static BaseInputController input;
    public static EngineController engine;
}