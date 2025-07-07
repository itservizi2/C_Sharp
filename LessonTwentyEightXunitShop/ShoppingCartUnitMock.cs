namespace LessonTwentyEightXunitShop
{
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using LessonTwentyEight;

        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Size { get; set; }
            public string Color { get; set; } = string.Empty;
        }

        public interface IProductRepository
        {
            Product? GetProductById(int productId); 
        }

        public class ShoppingCart
        {
            private readonly IProductRepository _productRepository;
            private readonly List<Product> _cartItems;

            public ShoppingCart(IProductRepository productRepository)
            {
                _productRepository = productRepository;
                _cartItems = new List<Product>();
            }

            public void AddToCart(int productId)
            {
                var product = _productRepository.GetProductById(productId);
                if (product != null)
                {
                    _cartItems.Add(product);
                }
            }

            public decimal CalculateTotal()
            {
                return _cartItems.Sum(item => item.Price);
            }
        }

        public class ShoppingCartTests
        {
            [Fact]
            public void AddToCart_ValidProductId_ProductIsAdded()
            {
                var mockRepo = new Mock<IProductRepository>();
                var product = new Product
                {
                    ProductId = 1,
                    Name = "Sneakers",
                    Price = 120.50m,
                    Size = 42,
                    Color = "Black"
                };

                mockRepo.Setup(repo => repo.GetProductById(1)).Returns(product);

                var cart = new ShoppingCart(mockRepo.Object);
                cart.AddToCart(1);

                Assert.Equal(120.50m, cart.CalculateTotal());
                mockRepo.Verify(repo => repo.GetProductById(1), Times.Once);
            }

            [Fact]
            public void AddToCart_InvalidProductId_NoItemAdded()
            {
                var mockRepo = new Mock<IProductRepository>();
                mockRepo.Setup(repo => repo.GetProductById(999)).Returns((Product?)null);

                var cart = new ShoppingCart(mockRepo.Object);
                cart.AddToCart(999);

                Assert.Equal(0m, cart.CalculateTotal());
                mockRepo.Verify(repo => repo.GetProductById(999), Times.Once);
            }
        }
    
}