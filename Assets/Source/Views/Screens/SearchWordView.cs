using System;
using Lean.Gui;
using UnityEngine;

namespace Source

{
    public class SearchWordView : MonoBehaviour
    {
        [SerializeField] private LeanButton setWord;

        public Screen screen;

        private void Start()
        {
            setWord.OnClick.AddListener(ClickToSetWord);
        }


        public event Action OnClickToCreateWord;

        private void ClickToSetWord()
        {
            OnClickToCreateWord?.Invoke();
        }
    }
}