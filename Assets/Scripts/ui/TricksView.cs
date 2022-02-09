using managers;
using TMPro;
using UnityEngine;

namespace ui
{
    public class TricksView : UIView
    {
        [SerializeField] private TMP_Text view;
        protected override bool Dynamic => false;

        private void Start()
        {
            GameRuntime.tricks.TricksUpdatedEvent += UpdateView;
        }

        protected override void UpdateView()
        {
            if (GameRuntime.tricks.ActiveTricks.Count > 0)
            {
                view.text = string.Join(" ", GameRuntime.tricks.ActiveTricks);
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}