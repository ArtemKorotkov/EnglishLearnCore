using System.Linq;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class DisplayWordsView : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private WordButtonView buttonViewPrefab;

        public Window window;

        public void DisplayWords(Folder folder)
        {
            Clear();
            foreach (var word in folder.Words.ToList())
            {
                WordButtonView  folderButtonView = Instantiate(buttonViewPrefab, content, false);
                folderButtonView.NativeValue = word.NativeValue;
                folderButtonView.ForeignValue = word.ForeignValue;
                folderButtonView.Progress = word.Progress;
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