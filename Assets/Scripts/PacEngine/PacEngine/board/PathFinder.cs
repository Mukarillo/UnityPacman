using System.Collections.Generic;
using PacEngine.utils;

namespace PacEngine.board
{
    public class PathFinder
    {
        public static Vector GetNextMove(Vector from, Vector to, List<Vector> availableDirections)
        {
            var minDist = int.MaxValue;
            Vector direction = new Vector();
            foreach (var dir in availableDirections)
            {
                var nPos = new Vector(from.x + dir.x, from.y + dir.y);
                var distance = GetDistance(nPos, to);
                if (!(distance <= minDist))
                    continue;

                minDist = distance;
                direction = dir;
            }

            return direction;
        }

        private static int GetDistance(Vector from, Vector to)
        {
            var dVec = new Vector(from.x - to.x, from.y - to.y);
            return (dVec.x * dVec.x) + (dVec.y * dVec.y);
        }
    }
}
