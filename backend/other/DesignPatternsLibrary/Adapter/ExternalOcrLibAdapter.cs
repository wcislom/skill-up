namespace DesignPatternsLibrary.Adapter
{
    public class ExternalOcrLibAdapter : ITargetInterface
    {
        private readonly ExternalOcrLib _library;

        public ExternalOcrLibAdapter(ExternalOcrLib library)
        {
            _library = library ?? throw new ArgumentNullException(nameof(library));
        }

        public Task<string> Read(Stream stream)
        {
            byte[] image = new byte[stream.Length];
            stream.ReadExactly(image);
            return Task.Run(() => _library.ReadText(image));
        }
    }
}
