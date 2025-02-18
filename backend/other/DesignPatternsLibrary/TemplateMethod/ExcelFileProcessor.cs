namespace DesignPatternsLibrary.TemplateMethod
{
    public class ExcelFileProcessor : FileProcessor
    {
        protected override Task<Stream> OpenFile(string path)
        {
            // assume we open via Excel library
            return Task.FromResult<Stream>(new MemoryStream());
        }

        protected override Task ProcessInternal()
        {
            return Task.CompletedTask;
        }

        protected override Task<bool> Validate()
        {
            // we can check if version is correct, etc.
            return Task.FromResult(true);
        }
    }
}
