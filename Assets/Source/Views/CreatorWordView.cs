using System;
using CryoDI;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Source
{
    public class CreatorWordView : CryoBehaviour
    {
        [SerializeField] private LeanButton createWordButton;
        [SerializeField] private LeanButton selectFolderButton;
        [SerializeField] private InputField nativeNameInput;
        [SerializeField] private InputField foreignNameInput;
        [SerializeField] private Text selectFolderText;
        [SerializeField] private ImageSelector selectImage;
        [Dependency] private NotificationView Notification { get; set; }

        public Window window;
        public UnityEvent<Word, Folder> OnCreateWord;
        public UnityEvent OnClickToSelectFolderButton;


        private Word _currentWord;
        private Folder _selectedFolder;

        private string[] testLinks = new[]
        {
            "https://i.ytimg.com/vi/gDlKZ7XJq40/default.jpg",
            "https://i.ytimg.com/vi/gDlKZ7XJq40/default.jpg"
        };

        private void Start()
        {
            createWordButton.OnClick.AddListener(CreateWord);
            selectFolderButton.OnClick.AddListener(ClickToSelectFolderButton);

            DisplayImages(testLinks);
        }


        public void DisplayImages(string[] links)
        {
            selectImage.DisplayImagesFromLinks(links);
        }


        public void SelectFolder(Folder folder)
        {
            _selectedFolder = folder;
            selectFolderText.text = $"Папка по умолчанию: {_selectedFolder.Name}";
        }

        private void ClickToSelectFolderButton()
        {
            OnClickToSelectFolderButton?.Invoke();
        }

        private void CreateWord()
        {
            if (nativeNameInput.text.Length <= 0)
            {
                Notification.ShowWarning("Введите слово на Русском");
                return;
            }

            if (foreignNameInput.text.Length <= 0)
            {
                Notification.ShowWarning("Введите слово на Английском");
                return;
            }

            _currentWord = new Word
            {
                ForeignValue = foreignNameInput.text,
                NativeValue = nativeNameInput.text,
                Progress = Progress.InProgress
            };

            OnCreateWord.Invoke(_currentWord, _selectedFolder);
            Notification.ShowGood(
                $"Слово: {_currentWord.NativeValue} Успешно добавлено  в папку {_selectedFolder.Name}");
            Clear();
        }

        private void Clear()
        {
            nativeNameInput.text = String.Empty;
            foreignNameInput.text = String.Empty;
        }
    }
}