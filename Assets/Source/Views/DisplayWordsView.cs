using System;
using System.Linq;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DisplayWordsView : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private WordButtonView buttonViewPrefab;
        public event Action<Word> OnClickToWord;

        public void Display(Folder folder)
        {
            Clear();
            foreach (var word in folder.Words.ToList())
            {
                WordButtonView wordButtonView = Instantiate(buttonViewPrefab, content, false);
                wordButtonView.DisplayWord(word);
                wordButtonView.Onclick += ClickToWord;
            }
        }

        public void AddWord(Word word)
        {
            WordButtonView wordButtonView = Instantiate(buttonViewPrefab, content, false);
            wordButtonView.DisplayWord(word);
            wordButtonView.Onclick += ClickToWord;
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        public void Clear()
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