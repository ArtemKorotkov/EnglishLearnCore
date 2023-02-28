using System;
using System.Collections.Generic;
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
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private CreateFolderView CreateFolder { get; set; }
        [Dependency] private NotificationView Notification { get; set; }


        private Type _currentState;
        private Type _stateByDefault;

        private Dictionary<Type, IWindow> _mapAllStates;
        private Dictionary<Type, Type> _mapPreviousStates;
        private Type _previousStateByDefault;


        private Camera _camera;


        public void Init()
        {
            _mapAllStates = new Dictionary<Type, IWindow>
            {
                [typeof(MainMenuView)] = MainMenu.window,
                [typeof(SearchWordView)] = SearchWord.window,
                [typeof(SetWordView)] = SetWord.window,
                [typeof(AllFoldersView)] = AllFolders.window,
                [typeof(WordsFromFolderView)] = WordsFromFolder.window,
                [typeof(CreateFolderView)] = CreateFolder.window,
                [typeof(NotificationView)] = Notification.window
            };

            _mapPreviousStates = new Dictionary<Type, Type>();

            SubscribeAllStateToClickToBack();
            ActivateAllStates();
            HideAllStates();

            _stateByDefault = typeof(MainMenuView);
            _currentState = _stateByDefault;
            SetState(_stateByDefault);
            SetDefaultPreviousState(_stateByDefault);

            MainMenu.dictFunctions.OnClickToSearchWord += () => SetState(typeof(SearchWordView));
            MainMenu.dictFunctions.OnClickToAllWords += () => SetState(typeof(AllFoldersView));
            SearchWord.OnClickToSetWord += () => SetState(typeof(SetWordView));
            AllFolders.OnClickToCreateFolder += () => SetState(typeof(CreateFolderView));
            AllFolders.OnClickToFolder += _ => SetState(typeof(WordsFromFolderView));
            SetWord.OnClickToAddWord += () => SetState(_stateByDefault);
        }

        private void SetState(Type state, bool setPreviousState = true)
        {
            if (setPreviousState)
            {
                _mapPreviousStates[state] = _currentState;
            }

            _mapAllStates[_currentState]?.Hide();
            _currentState = state;
            _mapAllStates[_currentState].Show();
        }

        public void Run()
        {
        }

        private void ChangeStateToPrevious()
        {
            var prevState = _mapPreviousStates[_currentState];
            SetState(prevState, false);
        }

        private void SubscribeAllStateToClickToBack()
        {
            foreach (var state in _mapAllStates)
                _mapAllStates[state.Key].OnClickToBack += ChangeStateToPrevious;
        }

        private void ActivateAllStates()
        {
            foreach (var state in _mapAllStates.Values)
            {
                state.Activate();
            }
        }

        private void HideAllStates()
        {
            foreach (var state in _mapAllStates.Values)
            {
                state.Hide();
            }
        }

        private void SetDefaultPreviousState(Type defaultValue)
        {
            foreach (var state in _mapAllStates)
                _mapPreviousStates[state.Key] = defaultValue;
        }
    }
}