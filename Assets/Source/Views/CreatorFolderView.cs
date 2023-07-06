using System;
using System.Collections.Generic;
using System.Linq;
using CryoDI;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class CreatorFolderView : CryoBehaviour
    {
        private const int MaxLengthNameFolder = 24;
        [Dependency] private NotificationView Notification { get; set; }


        [SerializeField] private InputField folderNameInput;
        [SerializeField] private LeanButton createFolderButton;
        [SerializeField] private LeanButton addNewWordButton;
        [SerializeField] private LeanButton addWordFromFolderButton;
        [SerializeField] private DisplayWordsView displayWords;
        [SerializeField] private RectTransform content;

        private Folder _createdFolder;
        private List<String> _foldersName;

        public Window window;
        public event Action<Folder> OnCreateFolder;
        public event Action OnClickToSelectWordFromFolder;
        public event Action OnClickToAddNewWord;

        public void SetFoldersName(List<string> foldersName)
        {
            _foldersName = foldersName;
        }

        private void Start()
        {
            _createdFolder ??= new Folder();
            _createdFolder.Words ??= new List<Word>();

            addNewWordButton.OnClick.AddListener(() => OnClickToAddNewWord?.Invoke());
            addWordFromFolderButton.OnClick.AddListener(() => OnClickToSelectWordFromFolder?.Invoke());

            createFolderButton.OnClick.AddListener(Create);

            displayWords.OnDeletedWord += RemoveWord;
        }



        public void AddWord(Word word)
        {
            _createdFolder.Words.Add(word);
            displayWords.AddWord(word, ButtonMode.Deliteble);

            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        public void AddWords(List<Word> words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        private void Create()
        {
            var folderNameLength = folderNameInput.text.Length;

            if (folderNameLength >= MaxLengthNameFolder)
            {
                Notification.ShowWarning(
                    $"Название папки слишком большое, максимальное количество символов = {MaxLengthNameFolder}");
                return;
            }

            if (folderNameLength == 0)
            {
                Notification.ShowWarning("Слишком короткое название");
                return;
            }

            if (_foldersName.Any(folder => folder == folderNameInput.text))
            {
                Notification.ShowWarning("Такая папка уже существует");
                return;
            }

            if (_createdFolder.Words.Count <= 0)
            {
                Notification.ShowWarning("Вы не добавили слова в папку");
                return;
            }

            _createdFolder.Name = folderNameInput.text;
            _createdFolder.Date = DateTime.Now;
            OnCreateFolder?.Invoke(_createdFolder);
            Notification.ShowGood($"Папка: {folderNameInput.text} успешно создана");
            Clear();
        }

        private void Clear()
        {
            folderNameInput.text = string.Empty;
            displayWords.Clear();
            
            _createdFolder = new Folder();
            _createdFolder.Words = new List<Word>();
        }

        private void RemoveWord(Word word)
        {
            _createdFolder.Words.Remove(word);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }
    }
}