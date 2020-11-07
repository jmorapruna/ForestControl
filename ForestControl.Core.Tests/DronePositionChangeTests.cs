using ForestControl.Core.Models;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Tests
{
    public class DronePositionChangeTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestPositionChangeAfterForwardStepOnEastDirection()
        {
            var initialPosition = new Vector(1, 1);
            var drone = new Drone(initialPosition, Directions.East, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(initialPosition.X + 1, drone.Position.X);
            Assert.AreEqual(initialPosition.Y, drone.Position.Y);
        }

        [Test]
        public void TestPositionChangeAfterForwardStepOnNorthDirection()
        {
            var initialPosition = new Vector(1, 1);
            var drone = new Drone(initialPosition, Directions.North, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(initialPosition.X, drone.Position.X);
            Assert.AreEqual(initialPosition.Y + 1, drone.Position.Y);
        }

        [Test]
        public void TestPositionShouldNotChangeAfterTurnLeftStep()
        {
            var initialPosition = new Vector(1, 1);
            var drone = new Drone(initialPosition, Directions.East, new Vector(5, 5));
  
            drone.ExecuteStep(ExecutionSteps.TurnLeft);

            Assert.AreEqual(initialPosition.X, drone.Position.X);
            Assert.AreEqual(initialPosition.Y, drone.Position.Y);
        }

        [Test]
        public void TestPositionShouldNotChangeAfterTurnRightStep()
        {
            var initialPosition = new Vector(1, 1);
            var drone = new Drone(initialPosition, Directions.East, new Vector(5, 5));

            drone.ExecuteStep(ExecutionSteps.TurnRight);

            Assert.AreEqual(initialPosition.X, drone.Position.X);
            Assert.AreEqual(initialPosition.Y, drone.Position.Y);
        }
    }
}