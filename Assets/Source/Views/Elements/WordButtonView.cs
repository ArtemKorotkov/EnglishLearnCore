using System;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;


namespace Source
{
    public class WordButtonView : MonoBehaviour
    {
        [SerializeField] private LeanButton button;
        [SerializeField] private LeanButton delete;
        [SerializeField] private LeanToggle select;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text nativeValue;
        [SerializeField] private ProgressDisplayer progressDisplayer;

        [Space] [Header("Custom UI Elements")] [SerializeField]
        private SplitCstUiView splitCstUi;

        [SerializeField] private SetMaxHeightCstUiView setMaxHeightCstUi;
        private Word _displayedWord;
        public event Action<Word> Onclick;
        public event Action<Word> OnSelect;
        public event Action<Word> OnDeSelect;
        public event Action<Word> OnDelete;


        public void SetMode(ButtonMode mode)
        {
            switch (mode)
            {
                case ButtonMode.Base:
                    delete.gameObject.SetActive(false);
                    progressDisplayer.gameObject.SetActive(true);
                    select.gameObject.SetActive(false);
                    break;

                case ButtonMode.Deliteble:
                    delete.gameObject.SetActive(true);
                    progressDisplayer.gameObject.SetActive(false);
                    select.gameObject.SetActive(false);
                    break;

                case ButtonMode.Selecteble:
                    delete.gameObject.SetActive(false);
                    progressDisplayer.gameObject.SetActive(false);
                    select.gameObject.SetActive(true);
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
            progressDisplayer.Set(word.ProgressType, word.Progress);
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

            select.Toggle();
            if (select.On)
            {
                Select();
            }
            else
            {
                DeSelect();
            }
        }

        private void Select()
        {
            OnSelect?.Invoke(_displayedWord);
        }

        private void DeSelect()
        {
            OnDeSelect?.Invoke(_displayedWord);
        }

        private void Delete()
        {
            OnDelete?.Invoke(_displayedWord);
            Destroy(gameObject);
        }
    }
}