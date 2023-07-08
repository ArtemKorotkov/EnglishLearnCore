using System;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class FolderButtonView : MonoBehaviour
    {
        [SerializeField] private LeanButton button;
        [SerializeField] private new Text name;
        [SerializeField] private Text countLearned;
        [SerializeField] private ProgressImage progressImage;
        private Folder _displayedFolder;
        public event Action<Folder> Onclick;
        
        
        public void DisplayFolder(Folder folder)
        {
            name.text = folder.Name;
            progressImage.SetIcon(folder.Progress);
            countLearned.text = "Выучено: " + folder.CountLearned + " из " + folder.Words?.Count.ToString();
            _displayedFolder = folder;
        }

        private void Start()
        {
            button.OnClick.AddListener(Click);
        }
        
        private void Click()
        {
            Onclick?.Invoke(_displayedFolder);
        }
    }
}