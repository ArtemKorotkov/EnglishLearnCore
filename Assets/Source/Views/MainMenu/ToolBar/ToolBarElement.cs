using System;
using Lean.Gui;
using Lean.Transition;
using UnityEngine;

namespace Source
{
    public class ToolBarElement : MonoBehaviour
    {
        public event Action<ToolBarElement> OnClick;

        [SerializeField] private LeanButton button;
        [SerializeField] private LeanPlayer selected;
        [SerializeField] private LeanPlayer deselected;

        private void Awake()
        {
            button.OnClick.AddListener(Click);
        }

        private void Click()
        {
            OnClick?.Invoke(this);
        }

        public void Select()
        {
            selected.Begin();
        }

        public void DeSelect()
        {
            deselected.Begin();
        }
    }
}