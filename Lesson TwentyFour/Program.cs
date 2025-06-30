namespace LessonTwentyFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order { Id = 101, Amount = 200.00 };

            IPaymentProcessor processor = new PayPalPayment(); 
            IOrderRepository repository = new OrderRepository();

            var service = new OrderService(processor, repository);
            service.FinalizeOrder(order);
        }
    }
}