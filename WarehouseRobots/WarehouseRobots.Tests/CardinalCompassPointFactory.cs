namespace WarehouseRobots.Tests
{
    using System;

    using CardinalCompassPoints;

    using Interfaces;

    internal class CardinalCompassPointFactory
    {
        public ICompassPoint Get(string typeId)
        {
            switch (typeId)
            {
                case "N":
                    return new North();
                case "E":
                    return new East();
                case "S":
                    return new South();
                case "W":
                    return new West();
            }

            throw new InvalidTypeIdentifierException();
        }

        internal class InvalidTypeIdentifierException : Exception
        {
        }
    }
}