namespace WarehouseRobots.Tests
{
    using System;

    /// <summary>
    /// The robot.
    /// </summary>
    internal class Robot
    {
        private readonly Coordinate coordinate;

        public Robot(Coordinate coordinate)
        {
            if (coordinate == null)
            {
                throw new CoordinateNullException();
            }

            this.coordinate = coordinate;
        }

        internal class CoordinateNullException : Exception
        {
        }
    }
}