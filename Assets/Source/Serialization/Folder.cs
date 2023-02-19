using System.Collections.Generic;
using System.Linq;

namespace Source.Serialization
{
    public struct Folder
    {
        public string Name;
        public int CountLearned;
        public List<Word> Words;
        public Progress Progress;
    }
}