using System;
using System.Collections.Generic;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class DisplayFoldersView : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private FolderButtonView buttonViewPrefab;
        public event Action<Folder> OnClickToFolder;

        public void Display(List<Folder> folders)
        {
            Clear();
            foreach (var folder in folders)
            {
                FolderButtonView folderButtonView = Instantiate(buttonViewPrefab, content, false);
                folderButtonView.DisplayFolder(folder);
                folderButtonView.Onclick += ClickToFolder;
            }
        }

        private void Clear()
        {
            var childCount = content.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        private void ClickToFolder(Folder folder)
        {
            OnClickToFolder?.Invoke(folder);
        }
    }
}