namespace DesignPatternsLibrary.Facade
{
    public interface IEcommerceFacade
    {
        Task<bool> PlaceOrder(int productId, int quantity);
    }
}
