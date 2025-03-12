namespace DesignPatternsLibrary.Mappings
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
