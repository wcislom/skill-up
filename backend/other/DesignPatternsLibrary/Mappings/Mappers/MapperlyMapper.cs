using Riok.Mapperly.Abstractions;

namespace DesignPatternsLibrary.Mappings.Mappers
{
    [Mapper]
    public static partial class MapperlyMapper
    {
         public static partial TypeB Map(this TypeA typeA);
    }
}
