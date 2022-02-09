using System.Collections.Generic;
using UnityEngine;

public class CollisionsController : BaseController
{
    [SerializeField] private string playerHurtFxId;

    private Collision playerHurtCollision = new Collision(Tag.Player, Tag.Obstacle);
    
    public enum Tag
    {
        Player,
        WheelFront,
        WheelBack,
        Obstacle
    }

    private readonly List<Collision> collisions = new List<Collision>();

    public void RegisterCollision(Collision collision)
    {
        collisions.Add(collision);
    }

    public void UnregisterCollision(Collision collision)
    {
        collisions.Remove(collision);
    }

    protected override void UpdateWork()
    {
        base.UpdateWork();
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        if (!collisions.Contains(playerHurtCollision)) return;
        
        GameRuntime.fx.PlayFx(playerHurtFxId);
    }
}