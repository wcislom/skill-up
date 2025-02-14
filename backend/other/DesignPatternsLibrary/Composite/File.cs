namespace DesignPatternsLibrary.Composite
{
    public class File : INode
    {
        public File(string name)
        {
            Name = name; 
        }
        public string Name { get; private set; }
    }
}
