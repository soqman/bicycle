using managers;
using UnityEngine;

namespace modules.bicycle
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private CollisionsController.Tag tag;
        [SerializeField] private CollisionsController.Tag targetTag;

        private Collision collision;

        private void Awake()
        {
            collision = new Collision(tag, targetTag);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag(targetTag.ToString())) return;

            RegisterCollision();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.collider.CompareTag(targetTag.ToString())) return;

            UnregisterCollision();
        }

        private void RegisterCollision()
        {
            GameRuntime.collisions.RegisterCollision(collision);
        }

        private void UnregisterCollision()
        {
            GameRuntime.collisions.UnregisterCollision(collision);
        }
    }
}