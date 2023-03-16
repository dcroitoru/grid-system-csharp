using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridSystem.GridSystem
{
    public class Geometry
    {
        public static int[] CreateInterval(int x0, int x1)
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


        public static Point[] CreateSegmentOnX(int[] interval, int y) => interval.Select(x => new Point(x, y)).ToArray();
        public static Point[] CreateSegmentOnY(int[] interval, int x) => interval.Select(y => new Point(x, y)).ToArray();
        public static Point[] CreateArea(Point p0, Point p1)
        {
            int[] xInterval = CreateInterval(p0.x, p1.x);
            int[] yInterval = CreateInterval(p0.y, p1.y);
            Point[][] ySegments = yInterval.Select((y) => CreateSegmentOnX(xInterval, y)).ToArray();

            return ySegments.SelectMany(x => x).Distinct().ToArray();

        }

        public static Point[] CreateHalfPerimeter(Point p0, Point p1)
        {
            int[] xInterval = CreateInterval(p0.x, p1.x);
            int[] yInterval = CreateInterval(p0.y, p1.y);

            return CreateSegmentOnX(xInterval, p0.y).Concat(CreateSegmentOnY(yInterval, p1.x)).Distinct().ToArray();
        }

        public static Point[] CreateHalfPerimeterFlipped(Point p0, Point p1)
        {
            int[] xInterval = CreateInterval(p0.x, p1.x);
            int[] yInterval = CreateInterval(p0.y, p1.y);

            return CreateSegmentOnY(yInterval, p0.x).Concat(CreateSegmentOnX(xInterval, p1.y)).ToArray();
        }

        public static Point[] CreatePoint(Point p0, Point p1)
        {
            return new[] { p1 };
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
