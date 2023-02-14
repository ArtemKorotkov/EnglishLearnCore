using System;
using Lean.Transition;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class Window : MonoBehaviour, IWindow

    {
        [SerializeField] private Button back;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private LeanPlayer show;
        [SerializeField] private LeanPlayer hide;

        private float _targetAlpha;

        public event Action OnClickToBack;

        public event Action OnShow;
        public event Action OnHide;


        public bool IsShown { get; private set; }


        private void Awake()
        {
            hide.Begin();
            back?.onClick.AddListener(ClickToBack);
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

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        private void ClickToBack()
        {
            OnClickToBack?.Invoke();
        }
    }
}