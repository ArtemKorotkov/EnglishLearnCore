using System;
using UnityEngine;

namespace Source.MainScen
{
    [Serializable]
    public class MainMenuView : MonoBehaviour

    {
        public Screen screen;

        public DictFunctionsView dictFunctions;
        public ToolBarView toolBarView;
        public SettingsView settings;
        public HomeView home;
    }
}