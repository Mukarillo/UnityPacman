using System;
using PacEngine.utils;

namespace PacEngine.board.prizes
{
    public class PrizeFactory
    {
        public enum PrizeTypes
        {
            NONE = 0,
            PAC_DOTS = 1,
            POWER_PELLETS = 2
        }

        public static AbstractPrize GetPrize(PrizeTypes prizeType, Vector position)
        {
            switch(prizeType)
            {
                case PrizeTypes.NONE:
                    return null;
                case PrizeTypes.PAC_DOTS:
                    return new PacDot(position);
                case PrizeTypes.POWER_PELLETS:
                    return new PowerPellet(position);
            }

            throw new PacException($"Prize of type {prizeType} is not implemented in PrizeFactory.GetPrize");
        }
    }
}
