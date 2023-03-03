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
        [SerializeField] private LeanButton addWordFromSearchButton;
        [SerializeField] private LeanButton addWordFromFolderButton;
        [SerializeField] private DisplayWordsView displayWords;
        [SerializeField] private RectTransform content;

        private Folder _createdFolder;
        private List<String> _foldersName;

        public Window window;
        public event Action<Folder> OnCreateFolder;

        public void SetFoldersName(List<string> foldersName)
        {
            _foldersName = foldersName;
        }

        private void Start()
        {
            _createdFolder ??= new Folder();
            _createdFolder.Words ??= new List<Word>();
            
            addWordFromSearchButton.OnClick.AddListener(AddWord);
            addWordFromFolderButton.OnClick.AddListener(AddWord);
            createFolderButton.OnClick.AddListener(Create);

            displayWords.OnDeletedWord += RemoveWord;
        }

        private void AddWord()
        {
            var word = new Word();

            if (_createdFolder.Words.Count != 0)
            {
                var lastWord = _createdFolder.Words.Last();

                word.ForeignValue = lastWord.ForeignValue;
                word.NativeValue = lastWord.NativeValue;
                word.Progress = lastWord.Progress;
            }

            word.ForeignValue += "1";
            word.NativeValue += "1";

            _createdFolder.Words.Add(word);
            displayWords.AddWord(word, ButtonMode.Deliteble);

            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
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