namespace DesignPatternsLibrary.Facade
{
    public static class FacadeFactory
    {

        /// <summary>
        /// Opaque facade has to create dependencies itself
        /// </summary>
        /// <returns></returns>
        public static IEcommerceFacade CreateFacade()
        {
            return new ECommerceFacade(new InventoryService(), new OrderService(), new ShippingService());
        }
    }
}
