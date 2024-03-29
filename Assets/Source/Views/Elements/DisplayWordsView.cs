﻿using System;
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
        public event Action<Word> OnDeletedWord;

        public event Action<Word> OnSelectWord;
        public event Action<Word> OnDeSelectWord;

        public void Display(Folder folder, ButtonMode mode = ButtonMode.Base)
        {
            Clear();
            foreach (var word in folder.Words.ToList())
            {
                WordButtonView wordButtonView = Instantiate(buttonViewPrefab, content, false);
                wordButtonView.DisplayWord(word);
                wordButtonView.SetMode(mode);
                wordButtonView.Onclick += ClickToWord;
                wordButtonView.OnDelete += DeleteWord;
                wordButtonView.OnSelect += SelectWord;
                wordButtonView.OnDeSelect += DeSelectWord;
            }
        }

        public void AddWord(Word word, ButtonMode mode = ButtonMode.Base)
        {
            WordButtonView wordButtonView = Instantiate(buttonViewPrefab, content, false);
            wordButtonView.DisplayWord(word);
            wordButtonView.SetMode(mode);
            wordButtonView.Onclick += ClickToWord;
            wordButtonView.OnDelete += DeleteWord;
            wordButtonView.OnSelect += SelectWord;
            wordButtonView.OnDeSelect += DeSelectWord;
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
        private void DeleteWord(Word word)
        {
            OnDeletedWord?.Invoke(word);
        }
        private void SelectWord(Word word)
        {
            OnSelectWord?.Invoke(word);
        }
        private void DeSelectWord(Word word)
        {
            OnDeSelectWord?.Invoke(word);
        }
        
    }
}