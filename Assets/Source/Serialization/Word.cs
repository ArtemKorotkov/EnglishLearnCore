namespace Source.Serialization
{
    public struct Word
    {
        public string NativeValue;
        public string ForeignValue;
        public Progress Progress;

        public Word(string nativeValue, string foreignValue, Progress progress)
        {
            NativeValue = nativeValue;
            ForeignValue = foreignValue;
            Progress = progress;
        }
    }
}