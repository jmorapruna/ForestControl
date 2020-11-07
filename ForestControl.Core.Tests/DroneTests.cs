using ForestControl.Core.Models;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Tests
{
    public class DroneTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestDirectionShouldNotChangeAfterGoForwardStep()
        {
            var drone = new Drone(new Position(1, 1), Directions.East);
            
            drone.ExecuteStep(ExecutionSteps.GoForward);

            Assert.AreEqual(Directions.East, drone.Direction);
        }

        [Test]
        public void TestDirectionAfterGoTurnLeftStep()
        {
            var drone = new Drone(new Position(1, 1), Directions.East);

            drone.ExecuteStep(ExecutionSteps.TurnLeft);

            Assert.AreEqual(Directions.North, drone.Direction);
        }


        [Test]
        public void TestDirectionAfterGoTurnRightStep()
        {
            var drone = new Drone(new Position(1, 1), Directions.East);

            drone.ExecuteStep(ExecutionSteps.TurnRight);

            Assert.AreEqual(Directions.South, drone.Direction);
        }
    }
}