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
    class PubSubTestCase
    {
        [Test]
        public void Test1()
        {
            Publisher.Date = "26/01/2018";
            Publisher.Name = "Republic Day";
            Subscriber sub = new Subscriber();
            sub.date= "26/01/2018";
            sub.Message();

        }

        [Test]
        public void Test2()
        {
            Publisher.Date = "27/01/2018";
            Publisher.Name = "Republic Day";
            Subscriber sub = new Subscriber();
            sub.date = "27/01/2018";
            sub.Message();
        }
    }
}
