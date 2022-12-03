using System;
using System.Collections.Generic;
using Source.MainScen;

namespace Source
{
    public class MainMenuController: IController
    {
        private DictFunctionsScreen _dictFunctions;
        private DownMenuScreen _downMenu;
        private SettingsScreen _settings;
        private HomeScreen _home;
        

        private Dictionary<Type, IView> viewsStates;
        private IView currentState;
        public MainMenuController(MainMenuScreen mainMenu)
        {
            _dictFunctions = mainMenu.DictFunctions;
            _settings = mainMenu.Settings;
            _home = mainMenu.Home;
            
            _downMenu = mainMenu.DownMenu;
            _downMenu.OnClickToDictionary += () => SetState(_dictFunctions);;
            _downMenu.OnClickToHome += () => SetState(_home);
            _downMenu.OnClickToSettings += () => SetState(_settings);
            
        }

        public void Init()
        {
            //by default:
            SetState(_home);
            

        }

        private void SetState(IView state)
        {
            currentState?.Hide();

            currentState = state;
            currentState.Show();
        }

        
        public void Run()
        {
           
        }
    }
}