namespace DesignPatternsLibrary.Decorator
{
    public class DecoratorA : IDecorable
    {
        private readonly IDecorable _decorated;

        public DecoratorA(IDecorable decorated)
        {
            _decorated = decorated;
        }
        public async Task<string> Operation()
        {
            var decoratedOutput = await _decorated.Operation();
            return $"<DecoratorA>${decoratedOutput}</DecoractorA>";
        }
    }
}
