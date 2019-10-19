using System;
using PacEngine.utils;

namespace PacEngine.board.prizes
{
    public class PrizeFactory
    {
        public enum PrizeTypes
        {
            NONE
        }

        public static AbstractPrize GetPrize(PrizeTypes prizeType)
        {
            switch(prizeType)
            {
                case PrizeTypes.NONE:
                    return null;
            }

            throw new PacException($"Prize of type {prizeType} is not implemented in PrizeFactory.GetPrize");
        }
    }
}
