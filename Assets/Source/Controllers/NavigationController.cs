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
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private CreatorWordView CreatorWords { get; set; }
        [Dependency] private WordContentView WordContent { get; set; }
        [Dependency] private SelectWordsView SelectWords { get; set; }
        [Dependency("CreateFolder")] private SelectFolderView SelectFolderForCreationFolder { get; set; }
        [Dependency("CreateFolder")] private CreatorWordView CreatorWordForCreateFolder { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }


        private Screens _currentState;
        private Screens _stateByDefault;

        private Dictionary<Screens, IScreen> _mapAllStates;
        private Dictionary<Screens, Screens> _mapPreviousStates;
        private Screens _previousStateByDefault;


        private Camera _camera;

        public void Init()
        {
            _mapAllStates = new Dictionary<Screens, IScreen>
            {
                [Screens.MainMenu] = MainMenu.screen,
                [Screens.SearchWord] = SearchWord.screen,
                [Screens.AllFolders] = AllFolders.screen,
                [Screens.WordsFromFolder] = WordsFromFolder.screen,
                [Screens.CreatorFolder] = CreatorFolder.screen,
                [Screens.CreatorWords] = CreatorWords.screen,
                [Screens.SelectFolder] = SelectFolder.screen,
                [Screens.WordContent] = WordContent.screen,
                [Screens.SelectWords] = SelectWords.screen,
                [Screens.SelectFolderForCreationFolder] = SelectFolderForCreationFolder.screen,
                [Screens.CreatorWordForCreateFolder] = CreatorWordForCreateFolder.screen
            };

            _mapPreviousStates = new Dictionary<Screens, Screens>();

            SubscribeAllStateToClickToBack();
            ActivateAllStates();
            HideAllStates();

            _stateByDefault = Screens.MainMenu;
            _currentState = _stateByDefault;
            SetState(_stateByDefault);
            SetDefaultPreviousState(_stateByDefault);

            ScreenChanger.OnSetState += SetState;
            ScreenChanger.OnSetPreviousState += ChangeStateToPrevious;
        }

        private void SetState(Screens state, bool setPreviousState = true)
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

        private void SetDefaultPreviousState(Screens defaultValue)
        {
            foreach (var state in _mapAllStates)
                _mapPreviousStates[state.Key] = defaultValue;
        }
    }
}