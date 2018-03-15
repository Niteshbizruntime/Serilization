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
    class DelegateAsParameterTestCase
    {

        [Test]
        public void Test1()
        {
            DelegateAsParameter.i = 30;

            DelegateAsParameter.j = 50;

            int first = 30;
            DelegateAsParameter.Operation opp = new DelegateAsParameter.Operation(DelegateAsParameter.PercentIncrease) + new DelegateAsParameter.Operation(DelegateAsParameter.PerCentDecrease);
            
            Assert.AreEqual(DelegateAsParameter.Call(opp, first), 74);
        }

        [Test]
        public void Test2()
        {
            DelegateAsParameter.i = 100;

            DelegateAsParameter.j = 150;

            int first = 20;
            DelegateAsParameter.Operation opp = new DelegateAsParameter.Operation(DelegateAsParameter.PercentIncrease) + new DelegateAsParameter.Operation(DelegateAsParameter.PerCentDecrease);

            Assert.AreEqual(DelegateAsParameter.Call(opp, first), 240);
        }

    }
}
