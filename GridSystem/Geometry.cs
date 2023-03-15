using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridSystem.GridSystem
{
    public class Geometry
    {
        public static int[] createInterval(int x0, int x1)
        {
            int sign = Math.Sign(x1 - x0);
            sign = sign == 0 ? 1 : sign;
            int len = Math.Abs(x1 - x0 + sign);
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = x0 + i * sign;
            }

            return result;

        }


        public static Point[] createSegmentOnX(int[] interval, int y) => interval.Select(x => new Point(x, y)).ToArray();
        public static Point[] createSegmentOnY(int[] interval, int x) => interval.Select(y => new Point(x, y)).ToArray();
        public static Point[] createArea(Point p0, Point p1)
        {
            int[] xInterval = createInterval(p0.x, p1.x);
            int[] yInterval = createInterval(p0.y, p1.y);
            Point[][] ySegments = yInterval.Select((y) => createSegmentOnX(xInterval, y)).ToArray();

            return ySegments.SelectMany(x => x).Distinct().ToArray();

        }

    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"[{x},{y}]";
        public static Point KeyToPoint(string key)
        {
            var pair = key.Split("-").Select(int.Parse).ToArray();
            return new Point(pair[0], pair[1]);
        }

        public static string PointToKey(Point p)
        {
            return $"{p.x}-{p.y}";
        }
        
    }
}
