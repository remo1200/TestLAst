using api.Controllers;
using api.Models;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Tests
{
    public class ProductControllerTest
    {
        private readonly Mock<SqlDbContext> _mockSqlDbContext;
        private readonly ProductController _productController;

        public ProductControllerTest()
        {
            var options = new DbContextOptionsBuilder<SqlDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDataBase")
                            .Options;

            _mockSqlDbContext = new Mock<SqlDbContext>(options);

        }

        [Fact]
        public void ProductControllerGet()
        {
            // Add your test logic here
        }
    }
}
