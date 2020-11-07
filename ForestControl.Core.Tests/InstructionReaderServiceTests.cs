using ForestControl.Core.Models;
using ForestControl.Core.Services;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace ForestControl.Core.Tests
{
    public class InstructionReaderServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("0 0", 0, 0)]
        [TestCase("4 5", 4, 5)]
        [TestCase("10 20", 10, 20)]
        public void TestReadInitialPosition(string input, int expectedX, int expectedY)
        {
            var service = new InstructionReaderService();
            var result = service.ReadAreaDimensions(input);

            Assert.AreEqual(expectedX, result.X);
            Assert.AreEqual(expectedY, result.Y);
        }

        [Test]
        public void TestReadTwoLinesOfInstructions()
        {
            var service = new InstructionReaderService();
            var result = service.ReadTwoLinesOfInstructions("2 3 E", "LRMRMLLR");

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
        public void TestReadTwoLinesOfInstructions3rdInput()
        {
            var service = new InstructionReaderService();
            _ = service.ReadTwoLinesOfInstructions("2 3 E", "LRLRLRLRLR");
            _ = service.ReadTwoLinesOfInstructions("2 3 E", "RRRRLLLLMMMMM");
            var result = service.ReadTwoLinesOfInstructions("2 3 E", "LLRRMM");

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
    }
}