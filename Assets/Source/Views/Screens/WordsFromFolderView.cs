using System;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class WordsFromFolderView : MonoBehaviour
    {
        [SerializeField] private DisplayWordsView displayWords;
        private Folder _folder;
        public Screen screen;
        public event Action<Word, Folder> OnClickToWord;

        private void Start()
        {
            displayWords.OnClickToWord += ClickToWord;
        }

        public void DisplayWords(Folder folder)
        {
            displayWords.Display(folder);
            _folder = folder;
        }
        
        private void ClickToWord(Word word)
        {
            OnClickToWord?.Invoke(word, _folder);
        }
    }
}