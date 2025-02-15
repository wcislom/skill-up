namespace DesignPatternsLibrary.Composite
{
    public class Directory : Node
    {
        public Directory(string name)
            : base(name)
        {
        }
     

        public void Add(INode item)
        {
            item.Parent = this;
            _children.Add(item);
        }

        private readonly List<INode> _children = new();
    }
}
