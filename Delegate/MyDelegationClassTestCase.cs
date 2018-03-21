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
    class MyDelegationClassTestCase
    {
        [Test]
        public void Test1()
        {
            MyClass myClass1 = new MyClass();
            myClass1.MyEvent += new MyClass.MyDelegate(myClass1.Message);
            string msg = "Hello";
            myClass1.Event(msg);

        }

        [Test]
        public void Test2()
        {
            MyClass myClass1 = new MyClass();
            myClass1.MyEvent += new MyClass.MyDelegate(myClass1.Message);
            string msg = "GoodBye";
            myClass1.Event(msg);
        }
    }
}
