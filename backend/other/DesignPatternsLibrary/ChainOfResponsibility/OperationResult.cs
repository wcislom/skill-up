namespace DesignPatternsLibrary.ChainOfResponsibility
{
    public record OperationResult
    {
        public bool Success { get; init; }

        public required string HandledBy { get; init; }
    }
}
