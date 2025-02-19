namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public class DefaultHandler : IMessageHandler
    {
        public Task<OperationResult> HandleMessageAsync(IMessage message)
        {
            return Task.FromResult(new OperationResult { Success = true });
        }
    }
}
