namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public abstract class MessageHandlerBase : IMessageHandler
    {
        protected MessageHandlerBase(IMessageHandler nextHandler = null)
        {
            _nextHandler = nextHandler;
        }

        public Task<OperationResult> HandleMessageAsync(IMessage message)
        {
            if(CanHandle(message))
            {
                return HandleMessageInternalAsync(message);
            }
            else if(_nextHandler != null)
            {
                return _nextHandler.HandleMessageAsync(message);
            }
           
           throw new InvalidOperationException("No handler found for the message");
        }

        protected abstract Task<OperationResult> HandleMessageInternalAsync(IMessage message);

        protected abstract bool CanHandle(IMessage message);

        private readonly IMessageHandler? _nextHandler;

    }
}
