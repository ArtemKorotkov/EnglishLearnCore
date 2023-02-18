using System;
using Lean.Gui;
using UnityEngine;

namespace Source

{
    public class SearchWordView : MonoBehaviour
    {
        [SerializeField] private LeanButton setWord;

        public Window window;

        private void Start()
        {
            setWord.OnClick.AddListener(ClickToSetWord);
        }


        public event Action OnClickToSetWord;

        private void ClickToSetWord()
        {
            OnClickToSetWord?.Invoke();
        }
    }
}