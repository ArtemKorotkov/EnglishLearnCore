using Lean.Transition;
using UnityEngine;
using UnityEngine.UI;

public class NotificationView : MonoBehaviour
{
    [SerializeField] private Text warningText;
    [SerializeField] private RectTransform content;

    [SerializeField] private LeanPlayer OpenTransition;
    [SerializeField] private LeanPlayer CloseTransition;

    public void ShowWarning(string Warning)
    {
        OpenTransition.Begin();
        warningText.text = Warning;
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
}