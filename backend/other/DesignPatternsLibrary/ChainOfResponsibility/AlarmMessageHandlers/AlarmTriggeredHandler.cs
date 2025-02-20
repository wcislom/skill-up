namespace DesignPatternsLibrary.ChainOfResponsibility.AlarmMessageHandlers
{
    public class AlarmTriggeredHandler : MessageHandlerBase
    {
        public AlarmTriggeredHandler(IMessageHandler nextHandler = null) : base(nextHandler) 
        {
            
        }

        protected override bool CanHandle<T>(T message) => message != null && message.GetType() == typeof(AlarmMessage); // Can be even moved to base class

        protected override Task<OperationResult> HandleMessageInternalAsync<T>(T message)
        {
            return Task.FromResult(new OperationResult() { Success = true, HandledBy = nameof(AlarmTriggeredHandler) });
        }
    }
}
