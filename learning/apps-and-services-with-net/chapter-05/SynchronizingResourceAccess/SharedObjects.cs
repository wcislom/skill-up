namespace SynchronizingResourceAccess
{
    public static class SharedObjects
    {
        public static string? Message { get; set; }

        public static object Conch = new(); // shared object to lock, it has to be reference type, cannot be value type

        public static int Counter; // Another shared resource.
    }
}
