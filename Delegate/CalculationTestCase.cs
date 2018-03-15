using DelegatesAndEvent;
using NUnit.Framework;

namespace DeledatesAndEventTestClass
{
    [TestFixture]
    class CalculationTestCase
    {
        [Test]
        public void Test1()
        {
            Calculation.number = 20;
            Calculator c1 = new Calculator(Calculation.Add);
            Calculator c2 = new Calculator(Calculation.Mul);
            c1(30);
            c2(10);
            Assert.AreEqual(Calculation.GetNumber(), 500);
        }

        [Test]
        public void Test2()
        {
            Calculation.number = 30;
            Calculator c1 = new Calculator(Calculation.Add);
            Calculator c2 = new Calculator(Calculation.Mul);
            c1(70);
            c2(10);
            Assert.AreEqual(Calculation.GetNumber(), 1000);
        }

    }
}
