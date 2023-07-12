using System;
using System.Collections.Generic;

namespace Source.Serialization
{
    public class Folder
    {
        public DateTime Date;
        public string Name;
        public int CountLearned;
        public List<Word> Words;
        public ProgressType ProgressType;
        public int Progress;
    }
}