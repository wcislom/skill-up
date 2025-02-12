namespace DesignPatternsLibrary.Decorator
{
    public class Component : IDecorable
    {
        public Task<string> Operation()
        {
            return Task.FromResult("This comes from component");
        }
    }
}
