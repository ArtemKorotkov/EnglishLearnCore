using System;
using System.Collections.Generic;
using Source.MainScen;

namespace Source
{
    public class NavigationController: IController
    {
       
        private MainMenuScreen MainMenu;
        private SearchWordScreen SearchWord;
        private SetWordScreen SetWord;

        private IView CurentState;
        private IView StateByDefault;

        private Dictionary<Type, IView> MapAllStates;
        private Dictionary<Type, IView> MapPreviousStates;
        private IView PreviousStateByDefault;
        

        public NavigationController(MainMenuScreen mainMenu,SearchWordScreen searchWord,SetWordScreen setWord)
        {
            this.MainMenu = mainMenu;
            this.SearchWord = searchWord;
            this.SetWord = setWord;
            
            MapAllStates = new Dictionary<Type, IView>();
            MapAllStates[typeof(MainMenuScreen)] = MainMenu;
            MapAllStates[typeof(SearchWordScreen)] = SearchWord;
            MapAllStates[typeof(SetWordScreen)] = SetWord;
            
            MapPreviousStates = new Dictionary<Type, IView>();
            
        }

        public void Init()
        {
            SubscribeClikToBack();
            HideAllStates();
            StateByDefault = MainMenu;
            SetPreviousStatesByDefault(StateByDefault);
            
            SetState(StateByDefault);
            
            MainMenu.DictFunctions.OnClickToSearchWord += () => SetState(SearchWord);
            SearchWord.OnClickToSetWord += () => SetState(SetWord);
            
            SetWord.OnClickToAddWord += () => SetState(StateByDefault);
        }

        private void SetState(IView state,bool setPreviousState = true)
        {
            CurentState?.Hide();

            if (setPreviousState)
            {
                MapPreviousStates[state.GetType()] = CurentState;
            }
            
            CurentState = state;
            CurentState.Show();
        }

        public void Run()
        {
            
        }

        private void ChangeStateToPrevious()
        {
            
            SetState(MapPreviousStates[CurentState.GetType()],false);
        }

        private void SubscribeClikToBack()
        {
            foreach (var state in MapAllStates)
                MapAllStates[state.Key].OnClickToBack += ChangeStateToPrevious;
        }
        
        private void HideAllStates()
        {
            foreach (var state in MapAllStates)
                MapAllStates[state.Key].Hide();
        }
        
        private void SetPreviousStatesByDefault(IView defolt)
        {
            foreach (var state in MapAllStates)
                MapPreviousStates[state.Key] =  defolt;
        }
        
       
    }
}