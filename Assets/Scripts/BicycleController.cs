using UnityEngine;

public class BicycleController : BaseController
{
    [SerializeField] private Rigidbody2D pilot;
    [SerializeField] private Rigidbody2D bicycle;

    [SerializeField] private Vector3 startPosition;

    public float Distance => Mathf.Max(Mathf.Abs(startPosition.x - pilot.position.x), 0f);
    
    public override void Init()
    {
        Reset();
        base.Init();
    }

    public void Reset()
    {
        ResetBody(bicycle);
        ResetBody(pilot);
        SitToBicycle();
    }

    private void ResetBody(Rigidbody2D body)
    {
        body.angularDrag = 0f;
        body.velocity = Vector2.zero;
        body.transform.localPosition = Vector3.zero;
        body.transform.localRotation = Quaternion.identity;
    }

    private void SitToBicycle()
    {
        var joint = pilot.GetComponent<FixedJoint2D>();
        if (joint == null)
        {
            joint = pilot.gameObject.AddComponent<FixedJoint2D>();
        }

        joint.connectedBody = bicycle;
        joint.breakForce = 300f;
        joint.breakTorque = 300f;
        joint.dampingRatio = 1f;
    }
}