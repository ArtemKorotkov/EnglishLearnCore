using System;
using System.Collections.Generic;
using Lean.Gui;
using Sirenix.OdinInspector;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;


namespace Source
{
    public class WordButtonView : MonoBehaviour
    {
        [SerializeField] private LeanButton button;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text nativeValue;
        [SerializeField] private ProgressImage progressImage;
        
        [Space] [Header("Custom UI Elements")]
        [SerializeField] private SplitCstUiView splitCstUi;
        [SerializeField] private SetMaxHeightCstUiView setMaxHeightCstUi;
        private Word _displayedWord;
        public event Action<Word> Onclick;
        

        private void Start()
        {
           button.OnClick.AddListener(Click);
        }

        public void DisplayWord(Word word)
        {
            UpdateUiElements();
            _displayedWord = word;
            foreignValue.text = word.ForeignValue;
            nativeValue.text = word.NativeValue;
            progressImage.SetIcon(word.Progress);
            UpdateUiElements();
            UpdateUiElements();
        }

        [ContextMenu("Apply Now In Inspector")]
        private void UpdateUiElements()
        {
            splitCstUi.Apply();
            setMaxHeightCstUi.Apply();
        }

        private void Click()
        {
            Onclick?.Invoke(_displayedWord);
        }
        
    }
}