using WebAPIApp.Interfaces;
using WebAPIApp.Models;
using WebAPIApp.Services;

namespace WebAPITest
{
    public class Tests
    {
        ProductRepo _repo; 
        [SetUp]
        public void Setup()
        {
            //Arrange
            _repo = new ProductRepo();

        }

        //[Test]
        //public void Test1()
        //{
        //    //Action
        //    var myProduct = _repo.Add(new Product { Id = 103, Name = "ABC", Price = 12.3f, Quantity = 0 });
        //    //Assert
        //    Assert.IsNotNull(myProduct);
        //}

        [TestCase(101)]
        [TestCase(102)]
        [TestCase(103)]
        [TestCase(104)]
        public void Test1(int id)
        {
            //Action
            var myProduct = _repo.Add(new Product { Id = id, Name = "ABC", Price = 12.3f, Quantity = 0 });
            //Assert
            Assert.IsNotNull(myProduct);
        }


    }
}