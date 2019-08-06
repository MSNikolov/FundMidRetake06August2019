using System;
using System.Linq;
using System.Collections.Generic;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            var loot = Console.ReadLine().Split('|').ToList();

            var input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "Loot":
                        for (int i = 1; i < command.Length; i++)
                        {
                            if (!loot.Contains(command[i]))
                            {
                                loot.Insert(0, command[i]);
                            }
                        }
                        break;
                    case "Drop":
                        var ind = int.Parse(command[1]);
                        if (ind >= 0 && ind < loot.Count)
                        {
                            var item = loot[ind];

                            loot.RemoveAt(ind);

                            loot.Add(item);
                        }
                        break;
                    case "Steal":
                        var count = int.Parse(command[1]);

                        var stolen = new List<string>();

                        if (count < loot.Count && count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                stolen.Add(loot.Last());

                                loot.Remove(loot.Last());
                            }

                            stolen.Reverse();

                            Console.WriteLine($"{string.Join(", ", stolen)}");
                        }

                        else
                        {
                            //loot.Reverse();

                            Console.WriteLine($"{string.Join(", ", loot)}");

                            loot.Clear();
                        }

                        break;
                }

                input = Console.ReadLine();
            }
            if (loot.Count>0)
            {
                double sum = 0;
                for (int i = 0; i < loot.Count; i++)
                {
                    sum += loot[i].Length;
                }

                var avg = sum / loot.Count;

                Console.WriteLine($"Average treasure gain: {avg:f2} pirate credits.");
            }

            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
