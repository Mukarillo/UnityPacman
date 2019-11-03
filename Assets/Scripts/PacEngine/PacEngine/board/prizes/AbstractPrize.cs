using System;
using PacEngine.utils;

namespace PacEngine.board.prizes
{
    public abstract class AbstractPrize
    {
        public Action OnCollect;

        public bool Collected { get; private set; }

        public abstract PrizeFactory.PrizeTypes Type { get; }
        public Vector Position { get; private set; }

        public AbstractPrize(Vector position)
        {
            Position = position;
        }

        public void TryCollect()
        {
            if (Collected)
                return;

            Collect();
            Collected = true;
        }

        protected virtual void Collect()
        {
            OnCollect?.Invoke();
        }
    }
}
