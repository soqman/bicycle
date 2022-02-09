using UnityEngine;

namespace ui
{
    public abstract class UIView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        protected virtual string Id => gameObject.name;

        public void Show()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        protected virtual bool Dynamic { get; set; }

        private void Update()
        {
            if (Dynamic)
            {
                UpdateView();
            }
        }

        protected abstract void UpdateView();
    }
}