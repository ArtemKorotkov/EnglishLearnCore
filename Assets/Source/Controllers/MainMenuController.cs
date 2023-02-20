using System;
using System.Collections.Generic;
using System.Linq;
using CryoDI;
using Source.MainScen;
using Unity.VisualScripting;
using UnityEngine;

namespace Source
{
    public class MainMenuController : IController
    {
        [Dependency] private MainMenuView _mainMenu { get; set; }

        private DictFunctionsView _dictFunctions;
        private HomeView _home;
        private SettingsView _settings;


        private ToolBarView _toolBarView;

        private Dictionary<Type, IWindow> MapAllStates;

        private Dictionary<Type, string> ToolBarValuesIntrp;

        private IWindow currentState;


        public void Init()
        { 
            _dictFunctions = _mainMenu.dictFunctions;
            _settings = _mainMenu.settings;
            _home = _mainMenu.home;

            _toolBarView = _mainMenu.toolBarView;
            _toolBarView.OnClickToElement += SetStateByToolBarView;

            MapAllStates = new Dictionary<Type, IWindow>
            {
                [typeof(DictFunctionsView)] = _dictFunctions.window,
                [typeof(HomeView)] = _home.window,
                [typeof(SettingsView)] = _settings.window
            };

            ToolBarValuesIntrp = new Dictionary<Type, string>
            {
                [typeof(DictFunctionsView)] = "Dictionary",
                [typeof(HomeView)] = "Home",
                [typeof(SettingsView)] = "Settings"
            };

            foreach (var state in MapAllStates.Values)
            {
                state.Activate();
                state.Hide();
            }

            SetStateByDefault(typeof(HomeView));
        }

        private void SetState(IWindow state)
        {
            currentState?.Hide();

            currentState = state;
            currentState.Show();
        }


        private void SetStateByToolBarView(string gameObjectName)
        {
            var stateType = ToolBarValuesIntrp.Where(pair => pair.Value == gameObjectName).Select(pair => pair.Key)
                .ToList();

            if (stateType.Count > 1)
            {
                Debug.LogError("You use more then one gameObject in ToolBar with the same NativeValue");
            }

            SetState(MapAllStates[stateType.First()]);
        }

        private void SetStateByDefault(Type stateType)
        {
            SetState(MapAllStates[stateType]);
            var nameState = ToolBarValuesIntrp[stateType];
            _toolBarView.StateByDefault(nameState);
        }


        public void Run()
        {
        }
    }
}