using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIApp.Models;
using WebAPIApp.Services;

namespace WebAPITest
{
    public class EfProductRepoTest
    {

        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void TestGetAll()
        {
            //Arrange 
            //Moq for Context
            Mock<ShopContext> context = new Mock<ShopContext>();
            //List of employees
            List<Product> products = new List<Product>()
            {
                new Product(){Id=101,Name="ABC"},
                new Product(){Id=102,Name="XYZ"}
            };
            //Mock for DbSet of product
            var dbSetMoq = new Mock<DbSet<Product>>();
            //Setting up the DbSet<Employee> moq
            var queriableData = products.AsQueryable();
            dbSetMoq.As<IQueryable<Product>>().Setup(emp => emp.Provider).Returns(queriableData.Provider);
            dbSetMoq.As<IQueryable<Product>>().Setup(emp => emp.Expression).Returns(queriableData.Expression);
            dbSetMoq.As<IQueryable<Product>>().Setup(emp => emp.ElementType).Returns(queriableData.ElementType);
            dbSetMoq.As<IQueryable<Product>>().Setup(emp => emp.GetEnumerator()).Returns(queriableData.GetEnumerator());
            //Setting up the moq for context
            context.Setup(ctx => ctx.Products).Returns(dbSetMoq.Object);
            ProductRepoEF repo = new ProductRepoEF(context.Object);
            //Action
            var myProducts = repo.GetAll();
            //Assert
            Assert.AreEqual("ABC", myProducts.ToList()[0].Name);
        }
    }
}
