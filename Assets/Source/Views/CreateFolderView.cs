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
    public class CreateFolderView : CryoBehaviour
    {
        private const int MaxLengthNameFolder = 24;
        [SerializeField] private InputField folderName;
        [SerializeField] private LeanButton createFolder;
        [SerializeField] private LeanButton addWordFromSearch;
        [SerializeField] private LeanButton addWordFromFolder;
        [SerializeField] private DisplayWordsView displayWords;
        [SerializeField] private RectTransform content;
        [Dependency] private NotificationView Notification { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        public Window window;
        public event Action OnCreateFolder;

        private List<Word> _addedWords;
        private Folder _currentFolder;

        private void Start()
        {
            addWordFromSearch.OnClick.AddListener(AddWord);
            addWordFromFolder.OnClick.AddListener(AddWord);
            createFolder.OnClick.AddListener(CreateFolder);
            _addedWords = new List<Word>();
        }

        private void AddWord()
        {
            var word = new Word();
            if (_addedWords.Count != 0)
            {
                word = _addedWords.Last();
            }

            word.ForeignValue += "1";
            word.NativeValue += "1";
            _addedWords.Add(word);
            displayWords.AddWord(word);

            var folder = new Folder();
            folder.Words = _addedWords;
            _currentFolder = folder;
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        private void CreateFolder()
        {
            var folderNameLength = folderName.text.Length;

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

            if (Storage.AllFolders.Any(folder => folder.Name == folderName.text))
            {
                Notification.ShowWarning("Такая папка уже существует");
                return;
            }

            _currentFolder.Name = folderName.text;
            Storage.SaveFolder(_currentFolder);
            OnCreateFolder?.Invoke();
        }
    }
}