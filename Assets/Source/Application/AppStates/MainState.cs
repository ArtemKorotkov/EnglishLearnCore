using System.Collections.Generic;

namespace Source
{
    public class MainState : IApplicationState
    {
        private readonly Application _application;

        public bool Initialized { get; private set; }

        private List<IController> _controllers;

        public MainState(Application application)
        {
            application.SceneChanger.SwitchToMain();
            _application = application;
        }

        public void Init(MainContext context)
        {
            var viewContainer = context.ViewContainer;

            _controllers = new List<IController>
            {
                viewContainer.BuildUp(new ShowAllFolderController()),
                viewContainer.BuildUp(new NavigationController()),
                viewContainer.BuildUp(new MainMenuController()),
                viewContainer.BuildUp(new LocalizationController()),
                viewContainer.BuildUp(new WordController()),
                viewContainer.BuildUp(new CreatorFolderController())
            };

            foreach (IController controller in _controllers)
                controller.Init();

            Initialized = true;
        }

        public void Run()
        {
            foreach (IController controller in _controllers)
            {
                controller.Run();
            }
        }

        private void SwitchStateToLearning()
        {
            _application.SwitchState(new LearningState(_application));
        }
    }
}