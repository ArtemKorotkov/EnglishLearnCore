using System;
using Lean.Gui;
using UnityEngine;

namespace Source
{
    public class SetWordView : MonoBehaviour

    {
        [SerializeField] private LeanButton Add;
        public Window window;
        public event Action OnClickToAddWord;

        private void ClickToAddWord()
        {
            OnClickToAddWord?.Invoke();
        }

        private void Start()
        {
            Add.OnClick.AddListener(ClickToAddWord);
        }
    }
}