namespace DesignPatternsLibrary.Facade
{
    internal class ECommerceFacade : IEcommerceFacade
    {
        private readonly InventoryService _inventory;
        private readonly OrderService _orderService;
        private readonly ShippingService _shipping;

        public ECommerceFacade(InventoryService inventory, OrderService orderService, ShippingService shipping)
        {
            _inventory = inventory;
            _orderService = orderService;
            _shipping = shipping;
        }

        public Task<bool> PlaceOrder(int productId, int quantity)
        {
            if (_inventory.CheckStock(productId) < quantity)
            {
                return Task.FromResult(false);
            }

            var orderId = _orderService.Order(productId, 1);

            _shipping.ScheduleSchipping(orderId);

            return Task.FromResult(true);
        }
    }
}
