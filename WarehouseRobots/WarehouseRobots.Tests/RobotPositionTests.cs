// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RobotPositionTests.cs" company="None">
//   2016 copyright
// </copyright>
// <summary>
//   The tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WarehouseRobots.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    using WarehouseRobots.Tests.CardinalCompassPoints;

    /// <summary>
    /// A robots position and direction can be represented by 
    /// a combination of x and y co-ordinates and 
    /// a letter representing one of the four cardinal compass points. 
    /// The warehouse is divided up into a grid to simplify navigation. 
    /// An example position might be 0, 0, N, which means 
    /// the robot is in the bottom left corner of the warehouse and facing North.
    /// </summary>
    [TestFixture]
    public class RobotPositionTests
    {
        private static IEnumerable<TestCaseData> CardinalCompassPointFactoryTestCaseDatum
        {
            get
            {
                yield return new TestCaseData("N").Returns(typeof(North));
                yield return new TestCaseData("E").Returns(typeof(East));
                yield return new TestCaseData("S").Returns(typeof(South));
                yield return new TestCaseData("W").Returns(typeof(West));
            }
        }

        [Test]
        public void CanCreateCoordinate()
        {
            const int X = 0;
            const int Y = 0;

            var coordinate = new Coordinate(X, Y);
        }

        /// <summary>
        /// The warehouse position must be made with x and y.
        /// </summary>
        [Test]
        public void WarehousePositionMustBeMadeWithXandY()
        {
            const int X = 0;
            const int Y = 0;
            var position = new WarehousePosition(X, Y);
        }

        /// <summary>
        /// The warehouse position cannot have negative x.
        /// </summary>
        [Test]
        public void WarehousePositionCannotHaveNegativeX()
        {
            const int X = -1;
            const int Y = 0;
            TestDelegate testDelegate = () => new WarehousePosition(X, Y);
            Assert.That(testDelegate, Throws.TypeOf<WarehousePosition.NegativeXParameterException>());
        }

        /// <summary>
        /// The warehouse position cannot have negative y.
        /// </summary>
        [Test]
        public void WarehousePositionCannotHaveNegativeY()
        {
            const int X = 0;
            const int Y = -1;
            TestDelegate testDelegate = () => new WarehousePosition(X, Y);
            Assert.That(testDelegate, Throws.TypeOf<WarehousePosition.NegativeYParameterException>());
        }

        /// <summary>
        /// The can create north cardinal compass point.
        /// </summary>
        [Test]
        public void CanCreateNorthCardinalCompassPoint()
        {
            var north = new North();
        }

        /// <summary>
        /// The can create east cardinal compass point.
        /// </summary>
        [Test]
        public void CanCreateEastCardinalCompassPoint()
        {
            var east = new East();
        }

        /// <summary>
        /// The can create south cardinal compass point.
        /// </summary>
        [Test]
        public void CanCreateSouthCardinalCompassPoint()
        {
            var south = new South();
        }

        /// <summary>
        /// The can create west cardinal compass point.
        /// </summary>
        [Test]
        public void CanCreateWestCardinalCompassPoint()
        {
            var west = new West();
        }

        [Test]
        public void CanCreateCardinalCompassPointFactory()
        {
            var factory = new CardinalCompassPointFactory();
        }

        [Test, TestCaseSource(nameof(CardinalCompassPointFactoryTestCaseDatum))]
        public Type CardinalCompassPointFactoryTester(string typeId)
        {
            var factory = new CardinalCompassPointFactory();
            var compassPoint = factory.Get(typeId);

            return compassPoint?.GetType();
        }

        [Test]
        public void CannotPassInvalidCharacterToCompassPointFactoryGet()
        { 
            const string TypeId = "n";
            var factory = new CardinalCompassPointFactory();
            TestDelegate testDelegate = () => factory.Get(TypeId);

            Assert.That(testDelegate, Throws.TypeOf<CardinalCompassPointFactory.InvalidTypeIdentifierException>());
        }
        
        [Test]
        public void MustPassCoordinateToRobotConstructor()
        {
            var coordinate = new Coordinate(0, 0);
            var robot = new Robot(coordinate);
        }

        [Test]
        public void MustNotPassNullCoordinateToRobotConstructor()
        {
            Coordinate nullCoordinate = null;
            TestDelegate testDelegate = () => new Robot(nullCoordinate);

            Assert.That(testDelegate, Throws.TypeOf<Robot.CoordinateNullException>());
        }
    }
}