using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.MainScen
{
    [Serializable]
    public class MainMenuView : MonoBehaviour

    {
        public Window window;
        
        public DictFunctionsView dictFunctions;
        public ToolBarView toolBarView;
        public SettingsView settings;
        public HomeView home;
    }
}