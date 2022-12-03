using System;
using System.Net.Mime;
using UnityEngine;

namespace Source
{
    public class AppUpdate : MonoBehaviour
    {
        private Application _application;

        private void Start()
        {
            _application = Application.Shared;
        }

        private void Update()
        {
            _application.Run();
            
        }

        
    }
}