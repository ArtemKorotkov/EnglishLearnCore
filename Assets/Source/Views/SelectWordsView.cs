using System.Collections.Generic;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Source
{
    public class SelectWordsView : MonoBehaviour
    {
        [SerializeField] private DisplayWordsView displayWords;
        [SerializeField] private LeanButton finishSelectButton;
        [SerializeField] private Text buttonText;
        private List<Word> _selectedWords;

        public Window window;

        public UnityEvent<List<Word>> onSelectedWords;

        private void Start()
        {
            _selectedWords = new List<Word>();
            UpdateButtonText();
            displayWords.OnSelectWord += SelectWord;
            displayWords.OnDeSelectWord += DeSelectWord;
            finishSelectButton.OnClick.AddListener(SelectionFinished);
        }

        public void DisplayWords(Folder folder)
        {
            displayWords.Display(folder, ButtonMode.Selecteble);
        }

        private void SelectWord(Word word)
        {
            _selectedWords.Add(word);
            UpdateButtonText();
        }

        private void DeSelectWord(Word word)
        {
            _selectedWords.Remove(word);
            UpdateButtonText();
        }

        private void SelectionFinished()
        {
            onSelectedWords.Invoke(_selectedWords);
            _selectedWords = new List<Word>();
            UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            buttonText.text = $"Добавить {_selectedWords.Count} слов";
        }
    }
}