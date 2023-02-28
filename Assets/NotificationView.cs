using Lean.Transition;
using Source;
using UnityEngine;
using UnityEngine.UI;

public class NotificationView : MonoBehaviour
{
    [SerializeField] private Text warningText;
    [SerializeField] private RectTransform content;

    [SerializeField] private LeanPlayer OpenTransition;
    [SerializeField] private LeanPlayer CloseTransition;
    public Window window;

    public void ShowWarning(string Warning)
    {
        OpenTransition.Begin();
        warningText.text = Warning;
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
}