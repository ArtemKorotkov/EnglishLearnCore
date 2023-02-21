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

        public Folder(string name, int countLearned, List<Word> words, Progress progress)
        {
            Name = name;
            CountLearned = countLearned;
            Words = words;
            Progress = progress;
        }
    }
}