using System;

    public class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }
    }

    public interface IPaymentProcessor
    {
        void ProcessPayment(Order order);
    }

    public class CreditCardPayment : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing credit card payment...");
            
        }
    }

    public class PayPalPayment : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing PayPal payment...");
            
        }
    }

    public class BankTransferPayment : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing bank transfer payment...");
            
        }
    }

    public interface IOrderRepository
    {
        void Save(Order order);
        Order Load(int orderId);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Salvarea comenzii în baza de date...");
            
        }

        public Order Load(int orderId)
        {
            Console.WriteLine("Încărcarea comenzii din baza de date...");
            return new Order { Id = orderId, Amount = 100.0 }; 
        }
    }

    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IPaymentProcessor paymentProcessor, IOrderRepository orderRepository)
        {
            _paymentProcessor = paymentProcessor;
            _orderRepository = orderRepository;
        }

        public void FinalizeOrder(Order order)
        {
            _paymentProcessor.ProcessPayment(order);
            _orderRepository.Save(order);
        }
    }
