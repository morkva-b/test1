using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using AnalaizerClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(local)\SQLEXPRESS;Initial Catalog=t1;Integrated Security=True", "CreateStackTests", DataAccessMethod.Sequential)]
        public void TestCreateStack()
        {
            AnalaizerClass.expression = (string)TestContext.DataRow["TestValue"];
            ArrayList result = AnalaizerClassLibrary.AnalaizerClass.CreateStack();

            string expected = TestContext.DataRow["ResultValue"].ToString();
            ArrayList expectedList = new ArrayList(expected.Split(' '));

            // Порівнюємо отриманий результат з очікуваним
            CollectionAssert.AreEqual(expectedList, result);
        }
    }
}
