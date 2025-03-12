namespace DesignPatternsLibrary.Mappings.Mappers
{
    internal class TypeAToTypeBMapper : IMapper<TypeA, TypeB>
    {
        public TypeB Map(TypeA source)
        {
            return new TypeB(source.Value);
        }
    }
}
