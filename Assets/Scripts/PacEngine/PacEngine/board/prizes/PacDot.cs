using PacEngine.utils;

namespace PacEngine.board.prizes
{
    public class PacDot : AbstractPrize
    {
        public PacDot(Vector position) : base(position)
        {
        }

        public override PrizeFactory.PrizeTypes Type => PrizeFactory.PrizeTypes.PAC_DOTS;

        protected override void Collect()
        {
            base.Collect();

        }
    }
}
