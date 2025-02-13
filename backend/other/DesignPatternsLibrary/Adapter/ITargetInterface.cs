namespace DesignPatternsLibrary.Adapter
{
    public interface ITargetInterface
    {
        /// <summary>
        /// Extracts text from a stream
        /// </summary>
        /// <returns></returns>
        Task<string> Read(Stream stream);
    }
}
