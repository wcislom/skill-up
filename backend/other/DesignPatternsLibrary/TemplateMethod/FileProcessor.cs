namespace DesignPatternsLibrary.TemplateMethod
{
    public abstract class FileProcessor
    {
        protected abstract Task<Stream> OpenFile(string path);

        protected abstract Task<bool> Validate();

        protected abstract Task ProcessInternal();

        public async Task Process(string path)
        {
            var file = await OpenFile(path);
            if (file == null)
            {
                throw new FileNotFoundException("File not found");
            }

            if (!await Validate())
            {
                throw new InvalidOperationException("File is not valid");
            }

            await ProcessInternal();
        }
    }
}
