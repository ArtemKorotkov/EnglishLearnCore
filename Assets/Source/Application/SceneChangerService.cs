using UnityEngine.SceneManagement;


  
    namespace Source
    {
        public class SceneChangerService
        {
            private const string Main = "Main";
            private const string Learning = "Learning";
            

            public void SwitchToMain()
            {
                LoadScene(Main);
            }
        
            public void SwitchToLearning()
            {
                LoadScene(Learning);   
            }

            private void LoadScene(string sceneName)
            {
                if (SceneManager.GetActiveScene().name != sceneName)
                    SceneManager.LoadSceneAsync(sceneName);
            }
        }
    }
        
        
    
