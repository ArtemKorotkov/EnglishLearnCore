using System.Collections.Generic;
using System.Linq;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class CreateFolderView : MonoBehaviour
    {
        private const int MaxLengthNameFolder = 24;
        [SerializeField] private InputField folderName;
        [SerializeField] private LeanButton createFolder;
        [SerializeField] private LeanButton addWordFromSearch;
        [SerializeField] private LeanButton addWordFromFolder;
        [SerializeField] private DisplayWordsView displayWords;
        [SerializeField] private RectTransform content;
        [SerializeField] private NotificationView notification;
        public Window window;

        private List<Word> _addedWords;

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
            _addedWords.Add(word);
            displayWords.AddWord(word);
            
            var folder = new Folder();
            folder.Words = _addedWords;
            
            //displayWords.Display(folder);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        private void CreateFolder()
        {
            if (folderName.text.Length >= MaxLengthNameFolder)
            {
                notification.ShowWarning($"Название папки слишком большое, максимальное количество символов = {MaxLengthNameFolder}");
            }
        }
    }
}