using System;
using System.Linq;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class DisplayWordsView : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private WordButtonView buttonViewPrefab;
        public event Action<Word> OnClickToWord;

        public void Display(Folder folder)
        {
            Clear();
            foreach (var word in folder.Words.ToList())
            {
                WordButtonView folderButtonView = Instantiate(buttonViewPrefab, content, false);
                folderButtonView.DisplayWord(word);
                folderButtonView.Onclick += ClickToWord;
            }
        }

        private void Clear()
        {
            var childCount = content.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        private void ClickToWord(Word word)
        {
            OnClickToWord?.Invoke(word);
        }
    }
}