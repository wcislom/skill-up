namespace DesignPatternsLibrary.Composite
{
    public interface INode
    {
        public string Name { get; }

        public string Path { get; }

        public INode? Parent { get; set; }
    }
}
