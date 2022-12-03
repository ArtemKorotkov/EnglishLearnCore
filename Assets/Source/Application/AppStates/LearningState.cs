using UnityEngine.UI;

namespace Source
{
   

        public class LearningState : IApplicationState
        {

            private Application _application;

            public bool Initialized { get; private set; }

            public LearningState(Application application)
            {
                application.SceneChanger.SwitchToLearning();
                _application = application;
            }

            public void Init(LearningContext context)
            {

                //context.knopka1?.onClick.AddListener(SwitchStateToMain);


                Initialized = true;
            }

            public void Run()
            {

            }

            private void SwitchStateToMain()
            {
                _application.SwitchState(new MainState(_application));
            }
        }


    
}