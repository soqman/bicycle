using common;
using UnityEngine;

namespace modules.bicycle
{
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
            ResetBicycle();
            SitToBicycle();
        }

        private void ResetBicycle()
        {
            foreach (var item in bicycle.GetComponentsInChildren<Rigidbody2D>())
            {
                item.angularDrag = 0f;
                item.velocity = Vector2.zero;
            }

            bicycle.transform.localPosition = startPosition;
            bicycle.transform.localRotation = Quaternion.identity;
        }

        private void SitToBicycle()
        {
            pilot.simulated = false;
            pilot.transform.localPosition = Vector3.zero;
            pilot.transform.localRotation = Quaternion.identity;
            var joint = pilot.GetComponent<RelativeJoint2D>();
            if (joint == null)
            {
                joint = pilot.gameObject.AddComponent<RelativeJoint2D>();
            }

            joint.connectedBody = bicycle;
            joint.breakForce = 300;
            joint.breakTorque = 300f;
            pilot.simulated = true;
        }
    }
}