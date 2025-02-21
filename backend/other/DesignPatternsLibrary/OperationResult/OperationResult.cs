namespace DesignPatternsLibrary.OperationResult
{
    public record OperationResult<T>
    {
        public bool IsSuccess { get; private set; }

        public T? Value { get; private set; }

        private OperationResult()
        {
        }

        public OperationResult<T> Success(T value)
        {
            return new OperationResult<T> { Value = value, IsSuccess = true };
        }

        public OperationResult<T> Fail()
        {
            return new OperationResult<T> { Value = default, IsSuccess = false };
        }

    }
}
