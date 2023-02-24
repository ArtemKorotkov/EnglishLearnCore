using System;
using System.Collections.Generic;
using Lean.Gui;
using Sirenix.OdinInspector;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;


namespace Source
{
    public class WordButtonView : SerializedMonoBehaviour
    {
        [SerializeField] private LeanButton button;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text nativeValue;
        [SerializeField] private ProgressImage progressImage;
        [SerializeField] private List<ICstUI>  customUiElements;
        private Word _displayedWord;
        public event Action<Word> Onclick;
        

        private void Start()
        {
           button.OnClick.AddListener(Click);
        }

        public void DisplayWord(Word word)
        {
            _displayedWord = word;
            foreignValue.text = word.ForeignValue;
            nativeValue.text = word.NativeValue;
            progressImage.SetIcon(word.Progress);
            UpdateUiElements();
        }

        [ContextMenu("Apply Now In Inspector")]
        private void UpdateUiElements()
        {
            foreach (var cstUiElement in customUiElements)
            {
                cstUiElement.Apply();
            }
        }

        private void Click()
        {
            Onclick?.Invoke(_displayedWord);
        }
        
    }
}