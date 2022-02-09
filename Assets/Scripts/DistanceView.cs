using TMPro;
using UnityEngine;

public class DistanceView : UIView
{
    [SerializeField] private TMP_Text view;
    protected override bool Dynamic => true;

    protected override void UpdateView()
    {
        view.text = $"Distance: <color=red>{GameRuntime.bicycle.Distance:0.00}</color>";
    }
}