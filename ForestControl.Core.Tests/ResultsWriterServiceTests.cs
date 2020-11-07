using ForestControl.Core.Models;
using ForestControl.Core.Services;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Tests
{
    public class ResultsWriterServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task TestReadTwoLinesOfInstructions3rdInput()
        {
            var input1 = new ExecutionResult()
            {
                FinalDirection = Directions.East,
                FinalPosition = new Vector(5, 1),
            };

            var input2 = new ExecutionResult()
            {
                FinalDirection = Directions.North,
                FinalPosition = new Vector(3, 3),
            };

            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);

            var service = new ResultsWriterService(streamWriter);

            await service.WriteAResult(input1);
            await service.WriteAResult(input2);

            streamWriter.Flush();
            stream.Position = 0;

            var result = new StreamReader(stream).ReadToEnd();
            Assert.AreEqual("5 1 E\r\n3 3 N\r\n", result);
        }
    }
}