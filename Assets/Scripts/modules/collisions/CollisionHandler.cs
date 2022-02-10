using System.Collections;
using managers;
using UnityEngine;

namespace modules.collisions
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private CollisionsController.Tag tag;
        [SerializeField] private CollisionsController.Tag targetTag;
        [SerializeField] private float exitThreshold;

        private Collision collision;

        private Coroutine routine;

        private bool hasCollision;

        public bool HasCollision
        {
            get => hasCollision;
            set
            {
                if (hasCollision != value)
                {
                    hasCollision = value;
                    if (hasCollision)
                    {
                        RegisterCollision();
                    }
                    else
                    {
                        UnregisterCollision();
                    }
                }
            }
        }

        private void Awake()
        {
            collision = new Collision(tag, targetTag);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag(targetTag.ToString())) return;
            if (routine != null)
            {
                StopCoroutine(routine);
                routine = null;
            }

            HasCollision = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.collider.CompareTag(targetTag.ToString())) return;
            if (routine == null)
            {
                routine = StartCoroutine(CollisionExitRoutine());
            }
        }

        private IEnumerator CollisionExitRoutine()
        {
            var elapsed = 0f;
            while (elapsed < exitThreshold)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            HasCollision = false;
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