using System;
using Lean.Transition;
using Source;
using UnityEngine;
using UnityEngine.UI;

public class WarningMessageView : MonoBehaviour
{
    [SerializeField] private Text warningText;
    [SerializeField] private RectTransform content;

    [SerializeField] private LeanPlayer OpenTransition;
    [SerializeField] private LeanPlayer CloseTransition;

    public void Show(string Warning)
    {
        OpenTransition.Begin();
        warningText.text = Warning;
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
    public void Hide()
    {
        CloseTransition.Begin();
        warningText.text = String.Empty;
    }
}