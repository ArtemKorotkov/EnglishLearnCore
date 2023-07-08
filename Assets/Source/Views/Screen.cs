using System;
using Lean.Gui;
using Lean.Transition;
using UnityEngine;

namespace Source
{
    public class Screen : MonoBehaviour, IScreen

    {
        private float _targetAlpha;
        [SerializeField] private LeanButton back;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private LeanPlayer hide;

        [SerializeField] private LeanPlayer show;
        public event Action OnClickToBack;
        public event Action OnHide;
        public event Action OnShow;
        public bool IsShown { get; private set; }

        public void Activate()
        {
            gameObject.SetActive(true);
        }


        public void Hide()
        {
            canvasGroup.blocksRaycasts = false;
            IsShown = false;
            hide.Begin();

            OnHide?.Invoke();
        }

        public void Show()
        {
            canvasGroup.blocksRaycasts = true;
            IsShown = true;
            show.Begin();

            OnShow?.Invoke();
        }


        private void Awake()
        {
            hide.Begin();
            back.OnClick.AddListener(ClickToBack);
        }

        private void ClickToBack()
        {
            OnClickToBack?.Invoke();
        }
    }
}