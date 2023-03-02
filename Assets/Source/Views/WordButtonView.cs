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
        [SerializeField] private LeanButton delete;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text nativeValue;
        [SerializeField] private ProgressImage progressImage;

        [Space] [Header("Custom UI Elements")] [SerializeField]
        private SplitCstUiView splitCstUi;

        [SerializeField] private SetMaxHeightCstUiView setMaxHeightCstUi;
        private Word _displayedWord;
        public event Action<Word> Onclick;
        public event Action<Word> OnSelect;
        public event Action<Word> OnDelete;

        public void SetMode(ButtonMode mode)
        {
            switch (mode)
            {
                case ButtonMode.Base:
                    delete.gameObject.SetActive(false);
                    progressImage.gameObject.SetActive(true);
                    break;

                case ButtonMode.Deliteble:
                    delete.gameObject.SetActive(true);
                    progressImage.gameObject.SetActive(false);
                    break;
            }
        }


        private void Start()
        {
            button.OnClick.AddListener(Click);
            delete.OnClick.AddListener(Delete);
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
            splitCstUi.Apply();
            setMaxHeightCstUi.Apply();
        }

        private void Click()
        {
            Onclick?.Invoke(_displayedWord);
        }

        public void Select()
        {
            OnSelect?.Invoke(_displayedWord);
        }

        public void Delete()
        {
            OnDelete?.Invoke(_displayedWord);
            Destroy(gameObject);
        }
    }
}