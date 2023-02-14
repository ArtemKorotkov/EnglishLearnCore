using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Source.MainScen;
using UnityEngine;
using CryoDI;

namespace Source
{
    public class NavigationController : IController
    {
        [Dependency] private MainMenuView MainMenu { get; set; }
        [Dependency] private SearchWordView SearchWord { get; set; }
        [Dependency] private SetWordView SetWord { get; set; }
        [Dependency] private AllFoldersView AllFolders { get; set; }

        private Type CurentState;
        private Type StateByDefault;

        private Dictionary<Type, IWindow> MapAllStates;
        private Dictionary<Type, Type> MapPreviousStates;
        private Type PreviousStateByDefault;


        private Camera _camera;


        public void Init()
        {
            MapAllStates = new Dictionary<Type, IWindow>
            {
                [typeof(MainMenuView)] = MainMenu.window,
                [typeof(SearchWordView)] = SearchWord.window,
                [typeof(SetWordView)] = SetWord.window,
                [typeof(AllFoldersView)] = AllFolders.window
            };

            MapPreviousStates = new Dictionary<Type, Type>();

            SubscribeAllStateToClickToBack();
            ActivateAllStates();
            HideAllStates();
            
            StateByDefault = typeof(MainMenuView);
            CurentState = StateByDefault;
            SetState(StateByDefault);
            SetDefaultPreviousState(StateByDefault);

            MainMenu.dictFunctions.OnClickToSearchWord += () => SetState(typeof(SearchWordView));
            SearchWord.OnClickToSetWord += () => SetState(typeof(SetWordView));

            SetWord.OnClickToAddWord += () => SetState(StateByDefault);
        }

        private void SetState(Type state, bool setPreviousState = true)
        {
            if (setPreviousState)
            {

                MapPreviousStates[state] = CurentState;
            }

            MapAllStates[CurentState]?.Hide();
            CurentState = state;
            MapAllStates[CurentState].Show();
        }

        public void Run()
        {
        }

        private void ChangeStateToPrevious()
        {
            
            var prevState = MapPreviousStates[CurentState];
            SetState(prevState,false);
            
        }

        private void SubscribeAllStateToClickToBack()
        {
            foreach (var state in MapAllStates)
                MapAllStates[state.Key].OnClickToBack += ChangeStateToPrevious;
        }

        private void ActivateAllStates()
        {
            foreach (var state in MapAllStates.Values)
            {
                state.Activate();
            }
        }

        private void HideAllStates()
        {
            foreach (var state in MapAllStates.Values)
            {
                state.Hide();
            }
        }

        private void SetDefaultPreviousState(Type defaultValue)
        {
            foreach (var state in MapAllStates)
                MapPreviousStates[state.Key] = defaultValue;
        }
    }
}