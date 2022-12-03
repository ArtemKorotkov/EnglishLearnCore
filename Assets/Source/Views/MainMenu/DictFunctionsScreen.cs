using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DictFunctionsScreen: View

    {
        public Button SearchWord;
        public Button AddNewWord;
        public Button AllWords;
        public Button LearnWords;
        public Button RepeatWords;

        public event Action OnClickToSearchWord;

        private void Start()
        {
            SearchWord.onClick.AddListener(ClickToSearchWord);
        }

        private void ClickToSearchWord()
        {
            OnClickToSearchWord?.Invoke();
        }
    }
}