using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source
{
    public class Application
    {
        public static Application Shared { get; private set; }

        private IApplicationState _currentState;
        private SceneContext _currentContext;
        
        private bool _waitingContext;
    
        public SceneChangerService SceneChanger { get; private set; }
        


        [RuntimeInitializeOnLoadMethod]
        private static void EntryPoint()
        {
            Shared = new Application();
        }

        private Application()
        {
            Init();
        }

        private void Init()
        {
            var appCore = new GameObject("AppUpdate", typeof(AppUpdate));
            Object.DontDestroyOnLoad(appCore);
            
            SceneChanger = new SceneChangerService();
            
            _waitingContext = true;
            InitStateAsync();

        }


       
        public void Run()
        {
            if (_currentState == null) 
                return;
            
            if (_currentState.Initialized)
                _currentState.Run();
        }
        
        public void BindContext(SceneContext context)
        {
            _currentContext = context;
            _waitingContext = false;
        }
        
        private async void InitStateAsync()
        {
            while (_waitingContext)
                await Task.Delay(50);
            
            _currentState ??= _currentContext switch
            {
                MainContext _ => new MainState(this),
                LearningContext _ => new LearningState(this),
                _ => throw new ArgumentOutOfRangeException(nameof(_currentContext))
            };

            switch (_currentContext)
            {
                
                case MainContext mainContext when _currentState is MainState mainState:
                    mainState.Init(mainContext);
                    break;
                case LearningContext learningContext when _currentState is LearningState learningState:
                    learningState.Init(learningContext);
                    break;
                default:
                    throw new Exception($"Wrong state transition!");
            }
        }
        
        public void SwitchState(IApplicationState state)
        {
            _waitingContext = true;
            _currentState = state;
            InitStateAsync();
        }


    }

}