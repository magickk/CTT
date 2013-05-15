using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectUnderGit
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();
            counter.Count(100);
        }
    }

    public class Counter
    {
        private static async Task<TimeSpan> CountToThousand(string beginMsg, string endMsg)
        {
            var returnFunc = new Task<TimeSpan>(() => 
                {
                    var timer = new Stopwatch();
                    timer.Start();

                    Console.WriteLine(beginMsg);
                    for (var i = 0; i < 100; i++)
                    {
                        Console.Write(i);
                    }
                    Console.WriteLine(endMsg);

                    timer.Stop();
                    return timer.Elapsed;
                });

            return await returnFunc;
        }

        public async void Count(int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                var result = await CountToThousand(string.Format("Begin counting {0}", i), "Finished");
                Console.WriteLine(result);
            }
            Console.Read();
        }
    }

}
