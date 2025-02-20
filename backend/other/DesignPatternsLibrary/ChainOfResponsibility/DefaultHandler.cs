namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public class DefaultHandler : IMessageHandler
    {
        public Task<OperationResult> HandleMessageAsync<T>(T message)
        {
            return Task.FromResult(new OperationResult { Success = true, HandledBy = nameof(DefaultHandler) });
        }
    }
}
