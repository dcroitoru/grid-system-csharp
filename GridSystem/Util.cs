using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

namespace CustomGridSystem.GridSystem
{
    public class Util
    {
        public static void Log(params object[] args)
        {
            string result = string.Join(", ", args);

            Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
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

    }
}
