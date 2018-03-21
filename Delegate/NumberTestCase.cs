using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DelegatesAndEvent;

namespace DeledatesAndEventTestClass
{
    [TestFixture]
    class NumberTestCase
    {

        [Test]
        public void Test1()
        {
            int n = 12;
            Number myNumber = new Number(n);
            myNumber.PrintSquare();
            myNumber.PrintCube();

        }

        [Test]
        public void Test2()
        {
            int n = 15;
            Number myNumber = new Number(n);
            myNumber.PrintSquare();
            myNumber.PrintCube();
        }
    }
}
