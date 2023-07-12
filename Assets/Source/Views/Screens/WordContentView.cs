using System;
using CryoDI;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class WordContentView : CryoBehaviour
    {
        [SerializeField] private Text nativeValue;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text folderName;
        [SerializeField] private Text progressText;
        [SerializeField] private LeanButton editButton;
        [SerializeField] private LeanButton nextWordButton;
        [SerializeField] private LeanButton previousWordButton;

        public Screen screen;

        public event Action OnClickToNextWord;
        public event Action OnClickToPreviousWord;
        public event Action OnClickToEdit; 

        private void Start()
        {
            nextWordButton.OnClick.AddListener(() => OnClickToNextWord?.Invoke());
            previousWordButton.OnClick.AddListener(() => OnClickToPreviousWord?.Invoke());
            editButton.OnClick.AddListener(() => OnClickToEdit?.Invoke());
        }

        public void Display(Word word, Folder folder)
        {
            nativeValue.text = $"Значение на Русском: {word.NativeValue}";
            foreignValue.text = $"Значение на Английском: {word.ForeignValue}";
            folderName.text = $"Название Папки: {folder.Name}";

            switch (word.ProgressType)
            {
                case ProgressType.Completed:
                    progressText.text = "Выучено";
                    progressText.color = Color.green;
                    break;
                
                case ProgressType.Repeat:
                    progressText.text = "Повторить";
                    progressText.color = Color.yellow;
                    break;
                
                case ProgressType.InProgress:
                    progressText.text = "Изучается";
                    progressText.color = Color.cyan;
                    break;
                
            }
            
        }
    }
}