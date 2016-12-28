namespace WarehouseRobots.Tests
{
    using System;

    internal class WarehousePosition : Coordinate
    {
        public WarehousePosition(int x, int y) : base(x, y)
        {
            if (x < 0)
            {
                throw new NegativeXParameterException();
            }

            if (y < 0)
            {
                throw new NegativeYParameterException();
            }
        }

        /// <summary>
        /// The negative xCoordinate parameter exception
        /// </summary>
        public class NegativeXParameterException : Exception
        {
        }

        /// <summary>
        /// The negative yCoordinate parameter.
        /// </summary>
        public class NegativeYParameterException : Exception
        {
        }
    }
}