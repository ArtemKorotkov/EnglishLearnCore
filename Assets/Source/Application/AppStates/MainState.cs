using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class MainState : IApplicationState
    {
        
        private Application _application;
        
        public bool Initialized { get; private set; }

        private List<IController> _controllers;

        public MainState(Application application)
        {
            application.SceneChanger.SwitchToMain();
            _application = application;
        }
        
        public void Init(MainContext context)
        {
            
            var MainMenu = context.MainMenu;
            var SearchWord = context.SearchWord;
            var SetWord = context.SetWord;

            _controllers = new List<IController>
            {
               new NavigationController(MainMenu,SearchWord,SetWord),
               new MainMenuController(MainMenu),
               new LocalizationController()
            };

            foreach (IController controller in _controllers)
                controller.Init();

            Initialized = true;
        }

        public void Run()
        {
            foreach (IController controller in _controllers)
            {
            }
        }
        
        private void SwitchStateToLearning()
        {
            _application.SwitchState(new LearningState(_application));
        }
    }
}