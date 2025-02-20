namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public interface IMessageHandler
    {
        Task<OperationResult> HandleMessageAsync<T>(T message);
    }
}
