using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewProject;

namespace TestClass
{
    [TestFixture]
    class ProgramTestCase
    {
        [Test]
        public void Divide()
        {
            Program p = new Program();
            int i = 10, j = 2, c,k; 
            c= i / j;
            k = p.Divide(i, j);
            Assert.AreEqual(c,k);
        }

        [Test]
        public void Divide1()
        {
            Program p = new Program();
            int i = 10, j = 0, c, k;
            k = p.Divide(i, j);
           
        }

        [Test,ExpectedException(typeof(DivideByZeroException))]
        public void ExceptedExceptionTest()
        {
            throw new DivideByZeroException();

        }

       

    }
}
