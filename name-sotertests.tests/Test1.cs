using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.WebSockets;

namespace name_sotertests.tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestSortedNamesWithFile()
        {
            string[] args = { "D:\\Source\\repos\\name-sorter\\name-sorter\\files\\unsorted-name-list.txt" };
            name_sorter.Program.Main(args);
            Assert.IsTrue(File.Exists(args[0]));
        }
        [TestMethod]
        public void TestOrderNameItems()
        {
            string[] names = { "tom jones smith", "liam carl spinks" };

            var res = name_sorter.Program.OrderNameItems(names); 
            Assert.IsNotNull(res);
            Assert.AreEqual("jones", res[0]["MiddleName"]);
         }
        [TestMethod]
        public void TestWriteToFile() {
            string outputfile = "D:\\Source\\repos\\name-sorter\\name-sorter\\files\\test-sorted-names-list.txt";
            string[] names = { "tom jones smith", "liam carl spinks" };

            var res = name_sorter.Program.OrderNameItems(names);
            name_sorter.Program.WriteToFile(res, outputfile);

            Assert.IsTrue(File.Exists(outputfile));

        }

    }
}
