namespace DesignPatternsLibrary.Decorator
{
    public class DecoratorB : IDecorable
    {
        private readonly IDecorable _decorated;

        public DecoratorB(IDecorable decorated)
        {
            _decorated = decorated;
        }
        public async Task<string> Operation()
        {
            var decoratedOutput = await _decorated.Operation();
            return $"<DecoratorB>${decoratedOutput}</DecoractorB>";
        }
    }
}
