using Source.Serialization;

namespace Source
{
    public class SerializationController : IController
    {
        private BinaryStorage _binaryStorage;
        private JsonStorage _jsonStorage;

        public void Init()
        {
            var _jsonStorage = new JsonStorage();
        }

        public void Run()
        {
        }
    }
    
    
    
}