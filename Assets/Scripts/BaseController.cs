using UnityEngine;

public class BaseController : MonoBehaviour
{
    private bool isInited;
    private bool isStarted;
    
    private void Update()
    {
        if (isStarted) UpdateWork();
    }
    
    public virtual void Init()
    {
        if(isInited) return;
        isInited = true;
    }

    public virtual void StartWork()
    {
        isStarted = true;
    }

    protected virtual void UpdateWork()
    {
    }

    public virtual void StopWork()
    {
        isStarted = false;
    }
}