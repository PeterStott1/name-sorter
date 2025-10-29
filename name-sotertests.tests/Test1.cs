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
        }
    }
}
