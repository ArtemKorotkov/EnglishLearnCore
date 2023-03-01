using System;
using Lean.Transition;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class GoodMessageView : MonoBehaviour
    {
        [SerializeField] private Text goodText;
        [SerializeField] private RectTransform content;

        [SerializeField] private LeanPlayer OpenTransition;
        [SerializeField] private LeanPlayer CloseTransition;

        public void Show(string good)
        {
            OpenTransition.Begin();
            goodText.text = good;
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }
        public void Hide()
        {
            CloseTransition.Begin();
            goodText.text = String.Empty;
        }
    }
}