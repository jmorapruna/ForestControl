using ForestControl.Core.Models;
using ForestControl.Core.Services;
using NUnit.Framework;
using System.IO;
using System.Linq;
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

        [Test]
        public async Task TestReadTwoLinesOfInstructions()
        {
            var service = new InstructionReaderService(_GetMockedStream("2 3 E\nLRMRMLLR"));
            var result = await service.ReadTwoLinesOfInstructions();

            Assert.AreEqual(Directions.East, result.InitialDirection);
            Assert.AreEqual(2, result.InitialPosition.X);
            Assert.AreEqual(3, result.InitialPosition.Y);

            var expectedSteps = new[] {
                ExecutionSteps.TurnLeft,
                ExecutionSteps.TurnRight,
                ExecutionSteps.GoForward,
                ExecutionSteps.TurnRight,
                ExecutionSteps.GoForward,
                ExecutionSteps.TurnLeft,
                ExecutionSteps.TurnLeft,
                ExecutionSteps.TurnRight,
            };

            Assert.AreEqual(expectedSteps.Count(), result.Steps.Count());
            expectedSteps
                .Zip(result.Steps)
                .ToList()
                .ForEach(x => Assert.AreEqual(x.First, x.Second));
        }

        [Test]
        public async Task TestReadTwoLinesOfInstructions3rdInput()
        {
            var service = new InstructionReaderService(_GetMockedStream("2 3 E\nLRLRLRLRLR\n2 3 E\nRRRRLLLLMMMMM\n2 3 E\nLLRRMM"));
            _ = await service.ReadTwoLinesOfInstructions();
            _ = await service.ReadTwoLinesOfInstructions();
            var result = await service.ReadTwoLinesOfInstructions();

            Assert.AreEqual(Directions.East, result.InitialDirection);
            Assert.AreEqual(2, result.InitialPosition.X);
            Assert.AreEqual(3, result.InitialPosition.Y);

            var expectedSteps = new[] {
                ExecutionSteps.TurnLeft,
                ExecutionSteps.TurnLeft,
                ExecutionSteps.TurnRight,
                ExecutionSteps.TurnRight,
                ExecutionSteps.GoForward,
                ExecutionSteps.GoForward,
            };

            Assert.AreEqual(expectedSteps.Count(), result.Steps.Count());
            expectedSteps
                .Zip(result.Steps)
                .ToList()
                .ForEach(x => Assert.AreEqual(x.First, x.Second));
        }

        [Test]
        public async Task TestReadTwoLinesOfInstructionsWhenStreamEnds1()
        {
            var service = new InstructionReaderService(_GetMockedStream("2 3 E\nLRLRLRLRLR"));
            _ = await service.ReadTwoLinesOfInstructions();
            var result = await service.ReadTwoLinesOfInstructions();

            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task TestReadTwoLinesOfInstructionsWhenStreamEnds2()
        {
            var service = new InstructionReaderService(_GetMockedStream("2 3 E\n"));
            _ = await service.ReadTwoLinesOfInstructions();
            var result = await service.ReadTwoLinesOfInstructions();

            Assert.AreEqual(null, result);
        }
    }
}