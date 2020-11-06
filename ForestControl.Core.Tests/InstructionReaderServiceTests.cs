using ForestControl.Core.Models;
using ForestControl.Core.Services;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Tests
{
    public class InstructionReaderServiceTests
    {
        private static Stream _GetMockedStream(string content)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            return stream;
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("0 0", 0, 0)]
        [TestCase("4 5", 4, 5)]
        [TestCase("10 20", 10, 20)]
        public async Task TestReadInitialPosition(string input, int expectedX, int expectedY)
        {
            var service = new InstructionReaderService(_GetMockedStream(input));
            var result = await service.ReadInitialPositionAsync();

            Assert.AreEqual(expectedX, result.X);
            Assert.AreEqual(expectedY, result.Y);
        }
    }
}