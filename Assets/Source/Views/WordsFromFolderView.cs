using Source.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace Source
{
    public class WordsFromFolderView : MonoBehaviour
    {
        [SerializeField] private DisplayWordsView displayWords;
        private Folder _folder;
        public Window window;
        public UnityEvent<Word, Folder> OnClickToWord;

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