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
    class GenericDelegateTestCase
    {
        [Test]
        public void Test1()
        {
            GenericDelegate gd = new GenericDelegate();
            Interest obj = new Interest();
            obj.P = 1000; obj.R = 20;obj.T = 2;
            GenericDelegate.SI= gd.calcSI(obj);
           Assert.AreEqual( gd.check(400),true);

        }

        [Test]
        public void Test2()
        {
            GenericDelegate gd = new GenericDelegate();
            Interest obj = new Interest();
            obj.P = 2000; obj.R = 5; obj.T = 3;
            GenericDelegate.SI = gd.calcSI(obj);
            Assert.AreEqual(gd.check(300), true);
        }
    }
}
