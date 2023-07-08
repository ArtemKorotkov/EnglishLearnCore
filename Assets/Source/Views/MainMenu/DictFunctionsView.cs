using System;
using Lean.Gui;
using UnityEngine;

namespace Source
{
    public class DictFunctionsView: MonoBehaviour

    {
        public Screen screen;
        
        [SerializeField] private LeanButton searchWord;
        [SerializeField] private LeanButton addNewWord;
        [SerializeField] private LeanButton allWords;
        [SerializeField] private LeanButton learnWords;
        [SerializeField] private LeanButton repeatWords;

        public event Action OnClickToSearchWord;
        public event Action OnClickToAllFolders;
        public event Action OnClickToAddNewWord;

        private void Start()
        {
            searchWord.OnClick.AddListener(ClickToSearchWord);
            allWords.OnClick.AddListener(ClickToAllWords);
            addNewWord.OnClick.AddListener(ClickToAddNewWord);
        }

        private void ClickToSearchWord()
        {
            OnClickToSearchWord?.Invoke();
        }

        private void ClickToAllWords()
        {
            OnClickToAllFolders?.Invoke();
        }
        private void ClickToAddNewWord()
        {
            OnClickToAddNewWord?.Invoke();
        }
    }
}