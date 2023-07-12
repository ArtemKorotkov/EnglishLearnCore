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
            SetScreen(_stateByDefault);
            SetDefaultPreviousState(_stateByDefault);

            ScreenChanger.OnSetState += SetScreen;
            ScreenChanger.OnSetPreviousState += SetPreviousScreen;

            AllFolders.OnClickToCreateFolder += () => SetScreen(Screens.CreatorFolder);
            AllFolders.OnClickToFolder += _ => SetScreen(Screens.WordsFromFolder);
            WordsFromFolder.OnClickToWord += (_, _) => SetScreen(Screens.WordContent);

            CreatorWords.OnCreateWord += (_, _) => SetPreviousScreen();
            CreatorWords.OnClickToSelectFolderButton += () => SetScreen(Screens.SelectFolder);

            CreatorFolder.OnCreateFolder += _ => SetScreen(Screens.AllFolders, false);
            CreatorFolder.OnClickToAddNewWord += () => SetScreen(Screens.CreatorWordForCreateFolder);
            CreatorFolder.OnClickToSelectWordFromFolder += () => SetScreen(Screens.SelectFolderForCreationFolder);
            SelectFolderForCreationFolder.OnClickToFolder += (_) => SetScreen(Screens.SelectWords);
            SelectWords.onSelectedWords += _ => SetScreen(Screens.CreatorFolder, false);
            CreatorWordForCreateFolder.OnCreateWord += (_, _) => SetPreviousScreen();

            MainMenu.dictFunctions.OnClickToAllFolders += () => SetScreen(Screens.AllFolders);
            MainMenu.dictFunctions.OnClickToSearchWord += () => SetScreen(Screens.SearchWord);
            MainMenu.dictFunctions.OnClickToAddNewWord += () => SetScreen(Screens.CreatorWords);
            
            SelectFolder.OnClickToFolder += _ => SetScreen(Screens.CreatorWords, false);
        }

        private void SetScreen(Screens state, bool setPreviousState = true)
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

        private void SetPreviousScreen()
        {
            var prevState = _mapPreviousStates[_currentState];
            SetScreen(prevState, false);
        }

        private void SubscribeAllStateToClickToBack()
        {
            foreach (var state in _mapAllStates)
                _mapAllStates[state.Key].OnClickToBack += SetPreviousScreen;
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