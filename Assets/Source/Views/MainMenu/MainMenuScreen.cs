using System;
using UnityEngine;

namespace Source.MainScen
{
    [Serializable]
    public class MainMenuScreen : View

    {
        public DictFunctionsScreen DictFunctions;
        public DownMenuScreen DownMenu;
        public SettingsScreen Settings;
        public HomeScreen Home;
    }
}