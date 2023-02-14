using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DictFunctionsView: MonoBehaviour

    {
        public Window window;
        
        [SerializeField] private Button searchWord;
        [SerializeField] private Button addNewWord;
        [SerializeField] private Button allWords;
        [SerializeField] private Button learnWords;
        [SerializeField] private Button repeatWords;

        public event Action OnClickToSearchWord;

        private void Start()
        {
            searchWord.onClick.AddListener(ClickToSearchWord);
        }

        private void ClickToSearchWord()
        {
            OnClickToSearchWord?.Invoke();
        }
    }
}