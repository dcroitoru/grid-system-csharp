using System;

namespace GridSystem
{
    public class Util
    {
        public static void Log(params object[] args)
        {

            foreach (object arg in args)
            {
                Console.Write(arg.ToString() + " ");
                System.Diagnostics.Debug.Write(arg.ToString() + " ");
            }

            Console.WriteLine();
            System.Diagnostics.Debug.WriteLine("");


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



        public static Action Log2 = () => Console.Out.WriteLine("hah");

        public static Action Log2Ext = () => Log2();
    }
}
