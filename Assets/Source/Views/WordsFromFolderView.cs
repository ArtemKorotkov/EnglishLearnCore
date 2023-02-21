using System;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class WordsFromFolderView : MonoBehaviour
    {
        [SerializeField] private DisplayWordsView displayWords;
        public Window window;
        public event Action<Word> OnClickToWord;

        private void Start()
        {
            displayWords.OnClickToWord += ClickToWord;
        }
        public void DisplayWords(Folder folder)
        {
            displayWords.Display(folder);
        }


        private void ClickToWord(Word word)
        {
            OnClickToWord?.Invoke(word);
        }
    }
}