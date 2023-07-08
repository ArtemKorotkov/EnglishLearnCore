using System;
using System.Collections.Generic;
using System.Linq;
using CryoDI;
using Source.MainScen;
using Source.Services;
using UnityEngine;

namespace Source
{
    public class MainMenuController : IController
    {
        [Dependency] private MainMenuView _mainMenu { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }

        private DictFunctionsView _dictFunctions;
        private HomeView _home;
        private SettingsView _settings;


        private ToolBarView _toolBarView;

        private Dictionary<Type, IScreen> _mapAllStates;

        private Dictionary<Type, string> _toolBarValuesIntrp;

        private IScreen _currentState;


        public void Init()
        { 
            
            _dictFunctions = _mainMenu.dictFunctions;
            _dictFunctions.OnClickToAllFolders += () => ScreenChanger.SetScreen(Screens.AllFolders);
            _dictFunctions.OnClickToSearchWord += () => ScreenChanger.SetScreen(Screens.SearchWord);
            _dictFunctions.OnClickToAddNewWord += () => ScreenChanger.SetScreen(Screens.CreatorWords);

            _settings = _mainMenu.settings;
            _home = _mainMenu.home;

            _toolBarView = _mainMenu.toolBarView;
            _toolBarView.OnClickToElement += SetStateByToolBarView;

            _mapAllStates = new Dictionary<Type, IScreen>
            {
                [typeof(DictFunctionsView)] = _dictFunctions.screen,
                [typeof(HomeView)] = _home.screen,
                [typeof(SettingsView)] = _settings.screen
            };

            _toolBarValuesIntrp = new Dictionary<Type, string>
            {
                [typeof(DictFunctionsView)] = "Dictionary",
                [typeof(HomeView)] = "Home",
                [typeof(SettingsView)] = "Settings"
            };

            foreach (var state in _mapAllStates.Values)
            {
                state.Activate();
                state.Hide();
            }

            SetStateByDefault(typeof(HomeView));
        }

        private void SetState(IScreen state)
        {
            _currentState?.Hide();

            _currentState = state;
            _currentState.Show();
        }


        private void SetStateByToolBarView(string gameObjectName)
        {
            var stateType = _toolBarValuesIntrp.Where(pair => pair.Value == gameObjectName).Select(pair => pair.Key)
                .ToList();

            if (stateType.Count > 1)
            {
                Debug.LogError("You use more then one gameObject in ToolBar with the same NativeValue");
            }

            SetState(_mapAllStates[stateType.First()]);
        }

        private void SetStateByDefault(Type stateType)
        {
            SetState(_mapAllStates[stateType]);
            var nameState = _toolBarValuesIntrp[stateType];
            _toolBarView.StateByDefault(nameState);
        }


        public void Run()
        {
        }
    }
}