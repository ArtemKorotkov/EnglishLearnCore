using CryoDI;
using Source.Serialization;
using UnityEngine;


namespace Source
{
    public class DataController : IController
    {
        [Dependency] private IStorage Storage { get; set; }

        public void Init()
        {
           
        }

        public void Run()
        {
        }
    }
    
    
    
}