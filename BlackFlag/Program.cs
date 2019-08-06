using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());

            var dailyPlunder = double.Parse(Console.ReadLine());

            var expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dailyPlunder;


                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }

                if (i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }

            else
            {
                var percentage = totalPlunder / expectedPlunder * 100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
