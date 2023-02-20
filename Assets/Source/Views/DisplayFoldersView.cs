using System.Collections.Generic;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class DisplayFoldersView : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private FolderButtonView buttonViewPrefab;

        public Window window;

        public void DisplayFolders(List<Folder> folders)
        {
            Clear();
            foreach (var folder in folders)
            {
                FolderButtonView folderButtonView = Instantiate(buttonViewPrefab, content, false);

                folderButtonView.Name = folder.Name;
                folderButtonView.CountLearned = "Выучено: " + folder.CountLearned + " из " + folder.Words?.Count.ToString();
                folderButtonView.Progress = folder.Progress;
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
    }
}