using System;

namespace ProjectEuler.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var problem11 = new Business.Problem11();
            var answer = problem11.Solve();
            var stopTime = DateTime.Now;
            var duration = stopTime - startTime;
            Console.WriteLine("The greatest product of 4 entries, is {0}", answer);
            Console.WriteLine("Solution took {0} ms", duration.TotalMilliseconds);
            Console.WriteLine("=> Please, press any key to close");
            Console.ReadKey();
        }
    }
}