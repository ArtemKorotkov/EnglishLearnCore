using System;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DictFunctionsView: MonoBehaviour

    {
        public Window window;
        
        [SerializeField] private LeanButton searchWord;
        [SerializeField] private LeanButton addNewWord;
        [SerializeField] private LeanButton allWords;
        [SerializeField] private LeanButton learnWords;
        [SerializeField] private LeanButton repeatWords;

        public event Action OnClickToSearchWord;
        public event Action OnClickToAllWords;

        private void Start()
        {
            searchWord.OnClick.AddListener(ClickToSearchWord);
            allWords.OnClick.AddListener(ClickToAllWords);
        }

        private void ClickToSearchWord()
        {
            OnClickToSearchWord?.Invoke();
        }

        private void ClickToAllWords()
        {
            OnClickToAllWords?.Invoke();
        }
    }
}