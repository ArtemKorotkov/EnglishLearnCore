using System;
using System.Collections.Generic;
using Source.MainScen;
using UnityEngine;
using CryoDI;
using Source.Services;

namespace Source
{
    public class NavigationController : IController
    {
        [Dependency] private MainMenuView MainMenu { get; set; }
        [Dependency] private SearchWordView SearchWord { get; set; }
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private CreatorFolderView CreatorFolder { get; set; }
        [Dependency] private CreatorWordView CreatorWords { get; set; }
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private WordContentView WordContent { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }
        [Dependency] private SelectWordsView SelectWords { get; set; }
        [Dependency("CreateFolder")] SelectFolderView SelectFolderForCreationFolder { get; set; }
        [Dependency("CreateFolder")] CreatorWordView CreatorWordForCreateFolder { get; set; }
        


        private Type _currentState;
        private Type _stateByDefault;

        private Dictionary<Type, IScreen> _mapAllStates;
        private Dictionary<Type, Type> _mapPreviousStates;
        private Type _previousStateByDefault;


        private Camera _camera;

        public void Init()
        {
            _mapAllStates = new Dictionary<Type, IScreen>
            {
                [typeof(MainMenuView)] = MainMenu.screen,
                [typeof(SearchWordView)] = SearchWord.screen,
                [typeof(AllFoldersView)] = AllFolders.screen,
                [typeof(WordsFromFolderView)] = WordsFromFolder.screen,
                [typeof(CreatorFolderView)] = CreatorFolder.screen,
                [typeof(CreatorWordView)] = CreatorWords.screen,
                [typeof(SelectFolderView)] = SelectFolder.screen,
                [typeof(WordContentView)] = WordContent.screen,
                [typeof(SelectWordsView)] = SelectWords.screen,
                [typeof(CreatorWordForCreationFolderView)] = CreatorWordForCreateFolder.screen,
                [typeof(SelectFolderForCreationFolderView)] = SelectFolderForCreationFolder.screen
            };

            _mapPreviousStates = new Dictionary<Type, Type>();

            SubscribeAllStateToClickToBack();
            ActivateAllStates();
            HideAllStates();

            _stateByDefault = typeof(MainMenuView);
            _currentState = _stateByDefault;
            SetState(_stateByDefault);
            SetDefaultPreviousState(_stateByDefault);

            ScreenChanger.OnSetState += SetState;
            ScreenChanger.OnSetPreviousState += ChangeStateToPrevious;
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