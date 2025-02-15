namespace DesignPatternsLibrary.Composite
{
    public abstract class Node : INode
    {
        protected Node(string name)
        {
            Name = name;
        }
        public string Name { get; protected set; }

        public string Path
        {
            get
            {
                var path = Name;
                var parent = Parent;
                while (parent != null)
                {
                    path = $"{parent.Name}/{path}";
                    parent = parent.Parent;
                }

                return path;
            }

        }

        public INode? Parent { get; set; }
    }
}
