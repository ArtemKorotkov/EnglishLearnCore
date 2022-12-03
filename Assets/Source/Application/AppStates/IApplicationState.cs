namespace Source
{
    public interface IApplicationState
    {
        public bool Initialized { get; }
        public void Run();
    }
}