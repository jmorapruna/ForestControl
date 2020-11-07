using ForestControl.Core.Models;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Tests
{
    public class DroneStepSequenceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSequence1()
        {
            var drone = new Drone(new Vector(3, 3), Directions.East, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.TurnLeft);

            Assert.AreEqual(3, drone.Position.X);
            Assert.AreEqual(3, drone.Position.Y);
            Assert.AreEqual(Directions.North, drone.Direction);
        }

        [Test]
        public void TestSequence2()
        {
            var drone = new Drone(new Vector(3, 3), Directions.East, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnRight);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnRight);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnRight);
            drone.ExecuteStep(ExecutionSteps.TurnRight);
            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(5, drone.Position.X);
            Assert.AreEqual(1, drone.Position.Y);
            Assert.AreEqual(Directions.East, drone.Direction);
        }

        [Test]
        public void TestSequence3()
        {
            var drone = new Drone(new Vector(1, 2), Directions.North, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.TurnLeft);
            drone.ExecuteStep(ExecutionSteps.GoForward);
            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(1, drone.Position.X);
            Assert.AreEqual(4, drone.Position.Y);
            Assert.AreEqual(Directions.North, drone.Direction);
        }

        [Test]
        public void TestCrossTheTopMargin()
        {
            var drone = new Drone(new Vector(5, 5), Directions.North, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(5, drone.Position.X);
            Assert.AreEqual(1, drone.Position.Y);
            Assert.AreEqual(Directions.North, drone.Direction);
        }

        [Test]
        public void TestCrossTheRightMargin()
        {
            var drone = new Drone(new Vector(5, 2), Directions.East, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(1, drone.Position.X);
            Assert.AreEqual(2, drone.Position.Y);
            Assert.AreEqual(Directions.East, drone.Direction);
        }

        [Test]
        public void TestCrossTheBottomMargin()
        {
            var drone = new Drone(new Vector(2, 1), Directions.South, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(2, drone.Position.X);
            Assert.AreEqual(5, drone.Position.Y);
            Assert.AreEqual(Directions.South, drone.Direction);
        }

        [Test]
        public void TestCrossTheLeftMargin()
        {
            var drone = new Drone(new Vector(1, 4), Directions.West, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(5, drone.Position.X);
            Assert.AreEqual(4, drone.Position.Y);
            Assert.AreEqual(Directions.West, drone.Direction);
        }

    }
}