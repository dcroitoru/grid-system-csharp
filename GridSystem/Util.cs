using static CustomGridSystem.Core.Constants;
using GridType = System.Collections.Generic.Dictionary<string, CustomGridSystem.Core.Constants.ToolType>;

using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using CustomGridSystem.Core;

namespace CustomGridSystem.GridSystem
{
    public class Util
    {
        public static void Log(params object[] args)
        {
            string result = string.Join(", ", args);

            Console.WriteLine(result);
            System.Diagnostics.Debug.WriteLine(result);
            Console.WriteLine("-----------------------");
            System.Diagnostics.Debug.WriteLine("-----------------------");


        }


        public static void LogColl(IEnumerable coll, int level = 0)
        {

            foreach (var item in coll)
            {

                if (item.GetType().IsArray)
                {
                    LogColl((IEnumerable)item);
                }
                else
                {
                    Console.Write($"{item} ");
                    System.Diagnostics.Debug.Write($"{item} ");

                }

            }



            Console.WriteLine();
            System.Diagnostics.Debug.WriteLine("");
            Console.WriteLine("-----------------------");
            System.Diagnostics.Debug.WriteLine("-----------------------");
        }

        public static int[] KeyToPair(string key)
        {
            return key.Split("-").Select(int.Parse).ToArray();
        }

        public static GridType TransformGridApplyTool(GridType grid, ToolType toolType)
        {
            GridType dict = grid.ToDictionary(x =>  x.Key, x => toolType);
            return dict;

        }

        public static GridType CreateGridApplyTool(Point[] points, ToolType toolType)
        {
            GridType dict = new();
            points.Select(Point.PointToKey).ToList().ForEach(item => dict.Add(item, toolType));
            return dict;
        }
    }
}
