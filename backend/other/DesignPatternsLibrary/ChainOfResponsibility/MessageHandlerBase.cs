using System.Diagnostics.CodeAnalysis;

namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public abstract class MessageHandlerBase : IMessageHandler
    {
        protected MessageHandlerBase(IMessageHandler nextHandler = null)
        {
            _nextHandler = nextHandler;
        }

        public Task<OperationResult> HandleMessageAsync<T>(T message)
        {
            if (CanHandle(message))
            {
                return HandleMessageInternalAsync(message);
            }
            else if (HasNext())
            {
                return _nextHandler.HandleMessageAsync(message);
            }
           
           throw new InvalidOperationException("No handler found for the message");
        }

        protected abstract Task<OperationResult> HandleMessageInternalAsync<T>(T message);

        protected abstract bool CanHandle<T>(T message);

        private readonly IMessageHandler? _nextHandler;

        [MemberNotNullWhen(true, nameof(_nextHandler))]
        private bool HasNext()
        {
            return _nextHandler != null;
        }

    }
}
