using System;
using System.Linq;
using CryoDI;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class CreateWordView : CryoBehaviour

    {
        [Dependency] private NotificationView Notification { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private SelectFolderView selectFolder { get; set; }

        [SerializeField] private LeanButton createWordButton;
        [SerializeField] private LeanButton selectFolderButton;
        [SerializeField] private InputField nativeNameInput;
        [SerializeField] private InputField foreignNameInput;
        [SerializeField] private Text selectFolderText;

        public Window window;
        public event Action OnCreateWord;
        public event Action OnClickToSelectFolder;


        private Word _currentWord;
        private Folder _selectedFolder;

        private void Start()
        {
            createWordButton.OnClick.AddListener(CreateWord);
            selectFolderButton.OnClick.AddListener(ClickToSelectFolder);
            selectFolder.OnClickToFolder += SelectFolder;
            SelectFolderByDefault();
        }


        private void SelectFolderByDefault()
        {
            var allFolders = Storage.AllFolders;
            _selectedFolder = allFolders.OrderByDescending(folder => folder.Date).FirstOrDefault();
            selectFolderText.text = $"Папка по умолчанию: {_selectedFolder.Name}";
        }
        private void SelectFolder(Folder folder)
        {
            
            _selectedFolder = folder;
            selectFolderText.text = $"Папка по умолчанию: {_selectedFolder.Name}";
        }

        private void ClickToSelectFolder()
        {
            OnClickToSelectFolder?.Invoke();
        }

        private void CreateWord()
        {
            if (nativeNameInput.text.Length <= 0)
            {
                Notification.ShowWarning("Введите слово на Русском ");
                return;
            }

            if (foreignNameInput.text.Length <= 0)
            {
                Notification.ShowWarning("Введите слово на Английском ");
                return;
            }

            _currentWord = new Word
            {
                ForeignValue = foreignNameInput.text,
                NativeValue = nativeNameInput.text,
                Progress = Progress.InProgress
            };

            _selectedFolder.Words.Add(_currentWord);
            Storage.SaveFolder(_selectedFolder);
            OnCreateWord.Invoke();
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