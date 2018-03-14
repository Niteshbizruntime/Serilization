using NUnit.Framework;
using NewProject;
namespace TestClass
{
    [TestFixture]
    class XmlSerializationTestCase
    {
        [Test]
        public void Test1()
        {
            StudentRecord obj = new StudentRecord();
            obj.SName = "Nitesh";
            obj.Add = "Btm";
            new XmlSerialization2().CallSerialization(obj);
            StudentRecord obj1 = new XmlSerialization2().CallDeSerialization();
            Assert.AreEqual(obj1.SName, null);
            Assert.AreEqual(obj1.Add, "Btm");
        }

        [Test]
        public void Test2()
        {
            StudentRecord obj = new StudentRecord();
            obj.SName = "Nitesh";
            obj.Add = "Btm";
            new XmlSerialization2().CallSerialization(obj);
            StudentRecord obj1 = new XmlSerialization2().CallDeSerialization();
            Assert.AreNotEqual(obj1.SName, "Nitesh");
            Assert.AreEqual(obj1.Add, "Btm");
        }
    }
}
