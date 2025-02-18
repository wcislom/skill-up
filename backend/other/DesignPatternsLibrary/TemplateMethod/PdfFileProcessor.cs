namespace DesignPatternsLibrary.TemplateMethod
{
    public class PdfFileProcessor : FileProcessor
    {
        protected override Task<Stream> OpenFile(string path)
        {
            // assume we open via Pdf library
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
