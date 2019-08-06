using System;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            var pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();

            var warShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();

            var maxHealthCap = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            while (input != "Retire")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "Fire":
                        var ind = int.Parse(command[1]);

                        var damage = int.Parse(command[2]);

                        if (ind >= 0 && ind < warShip.Length)
                        {
                            warShip[ind] -= damage;

                            if (warShip[ind] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");

                                Environment.Exit(0);
                            }
                        }
                        break;
                    case "Defend":
                        var startInd = int.Parse(command[1]);

                        var endInd = int.Parse(command[2]);

                        var dmg = int.Parse(command[3]);

                        if (startInd >= 0 && startInd < pirateShip.Length && endInd >= 0 && endInd < pirateShip.Length)
                        {
                            for (int i = startInd; i <= endInd; i++)
                            {
                                pirateShip[i] -= dmg;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");

                                    Environment.Exit(0);
                                }
                            }
                        }
                        break;
                    case "Repair":
                        var index = int.Parse(command[1]);

                        var health = int.Parse(command[2]);

                        if (index >= 0 && index < pirateShip.Length)
                        {
                            pirateShip[index] += health;
                            if (pirateShip[index] > maxHealthCap)
                            {
                                pirateShip[index] = maxHealthCap;
                            }
                        }
                        break;
                    case "Status":
                        var count = 0;

                        for (int i = 0; i < pirateShip.Length; i++)
                        {
                            if (pirateShip[i] < maxHealthCap*0.2)
                            {
                                count++;
                            }
                        }

                        Console.WriteLine($"{count} sections need repair.");

                        break;
                }

                input = Console.ReadLine();
            }
            var pirateShipSum = pirateShip.Sum();

            var warshipSum = warShip.Sum();

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");

            Console.WriteLine($"Warship status: {warshipSum}");
        }
    }
}
