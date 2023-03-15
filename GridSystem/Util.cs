using System.Collections.Generic;
using System;
using System.Linq;

namespace CustomGridSystem.GridSystem
{
    public class Util
    {
        public static void Log(params object[] args)
        {            

            foreach (object arg in args)
            {
                var str = arg.ToString() + "; ";
                Console.Write(str);
                System.Diagnostics.Debug.Write(str);
            }
            Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            Console.WriteLine("-----------------------");
            System.Diagnostics.Debug.WriteLine("-----------------------");


        }


        public static void LogColl<T>(IEnumerable<T> coll)
        {
            foreach (var item in coll)
            {
                Console.Write(item?.ToString() + "; ");
                System.Diagnostics.Debug.Write(item?.ToString() + " ");
            }

            Console.WriteLine();
            System.Diagnostics.Debug.WriteLine("");
        }

        public static int[] KeyToPair(string key)
        {
            return key.Split("-").Select(int.Parse).ToArray();
        }

        
    }
}
