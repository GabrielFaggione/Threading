using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class CountService
    {
        public CountService(int increment, int maxValue)
        {
            Increment = increment;
            MaxValue = maxValue;
            Count = 0;
        }

        public Task SumUpTo()
        {
            while (Count < MaxValue)
            {
                Count += Increment;
                Console.WriteLine($"{Count}/{MaxValue}");
                Thread.Sleep(100);
            }
            return Task.CompletedTask;
        }


        public int Increment { get; set; }
        public int MaxValue { get; set; }
        private int Count { get; set; }

    }
}
