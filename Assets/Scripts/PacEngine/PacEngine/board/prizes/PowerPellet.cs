using PacEngine.utils;

namespace PacEngine.board.prizes
{
    public class PowerPellet : AbstractPrize
    {
        public PowerPellet(Vector position) : base(position)
        {
        }

        public override PrizeFactory.PrizeTypes Type => PrizeFactory.PrizeTypes.POWER_PELLETS;

        protected override void Collect()
        {
            base.Collect();

            PacmanEngine.Instance.Ghosts.ForEach(x => x.Frightened());
        }
    }
}
