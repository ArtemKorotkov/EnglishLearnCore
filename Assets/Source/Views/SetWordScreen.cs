using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class SetWordScreen: View

    {
        public event Action OnClickToAddWord;

        [SerializeField] private Button Add;
        
        private void Start()
            {
                Add.onClick.AddListener(ClickToAddWord);
            }

        private void ClickToAddWord()
            {
                OnClickToAddWord?.Invoke();
            }
    }
}