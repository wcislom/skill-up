using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace DesignPatternsLibrary.OperationResult
{
    public abstract record class OperationResult<T>
    {
        public bool IsSuccess { get; private set; }

       

        private OperationResult()
        {
        }

        public static OperationResult<T> Success(T value)
        {
            return new SuccessfullOperationResult<T> { Value = value, IsSuccess = true };
        }

        public static OperationResult<T> Fail(params string[] messages)
        {
            return new FailureOperationResult<T> { IsSuccess = false, Messages = messages.ToImmutableList() };
        }

        private record SuccessfullOperationResult<T> : OperationResult<T>
        {
            public T? Value { get; init; }
        }

        private record FailureOperationResult<T> : OperationResult<T>
        {
            public ImmutableList<string> Messages { get; init; }
        }
    }
}
