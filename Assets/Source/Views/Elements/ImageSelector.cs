using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Lean.Transition;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Source.GoogleApi;
using UnityEngine;
using UnityEngine.Networking;

namespace Source
{
    public class ImageSelector : MonoBehaviour
    {
        [SerializeField] private LeanPlayer hide;
        [SerializeField] private LeanPlayer show;
        [SerializeField] private Transform content;
        [SerializeField] private SelectImageButton buttonPrfabButton;
        public event Action<string> OnSelect;


        public void Hide()
        {
            hide.Begin();
            Clear();
        }

        public void Show()
        {
            show.Begin();
        }

        private void Clear()
        {
            var childCount = content.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        public void DisplayImagesFromLinks(string[] links)
        {
            
            Clear();
            
            foreach (var link in links)
            {
                if (link.Contains(".webp"))
                    continue;
                if (link.Contains(".gif"))
                    continue;

                SelectImageButton selectImage = Instantiate(buttonPrfabButton, content, false);
                selectImage.Display(link);
            }

            Show();
        }
        
        
    }
}