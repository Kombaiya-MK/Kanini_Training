using CalculatorWebAPP.Services;

namespace TestAppCalculator
{
    public class Tests
    {
        CalculatorOperations _opr;


        [SetUp]
        public void Setup()
        {
            //Arrange
            _opr = new CalculatorOperations();
        }

        [Test]
        public void TestAdd()
        {

            Assert.AreEqual(24 , _opr.Addition(12,12));//Positive Case
            Assert.AreEqual(-11, _opr.Addition(-1, -10));//Negative Number Addition
            Assert.AreEqual(0, _opr.Addition(-1, 1));//Negative & Positive Addition
            Assert.AreEqual(1, _opr.Addition(0, 1));//Zero Addition
        }

        [Test]
        public void TestSubtract()
        {
            Assert.AreEqual(0, _opr.Subtraction(12, 12));//Positive Case
            Assert.AreEqual(9, _opr.Subtraction(-1, -10));//Negative Number 
            Assert.AreEqual(-2, _opr.Subtraction(-1, 1));//Negative & Positive 
            Assert.AreEqual(-1, _opr.Subtraction(0, 1));//Zero 
        }

        [Test]
        public void TestMultiply()
        {
            Assert.AreEqual(144, _opr.Multiplication(12, 12));//Positive Case
            Assert.AreEqual(10, _opr.Multiplication(-1, -10));//Negative Number 
            Assert.AreEqual(-1, _opr.Multiplication(-1, 1));//Negative & Positive 
            Assert.AreEqual(0, _opr.Multiplication(0, 1));//Zero 
        }
        [Test]
        public void TestDivide()
        {
            Assert.AreEqual(1, _opr.Division(12, 12));//Positive Case
            Assert.AreEqual(10, _opr.Division(-10, -1));//Negative Number 
            Assert.AreEqual(-1, _opr.Division(-1, 1));//Negative & Positive 
            Assert.AreEqual(0, _opr.Division(0, 1));//Zero 
        }
    }
}