using System.Numerics;

namespace AdventOfCode.Days
{
    public class Day2 : IDay
    {
        public void RunPart1()
        {
            var position = new Vector2(0.0f, 0.0f);

            using var reader = new StreamReader("Inputs/Day2.txt");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var split = line.Split(' ');

                var vector = split[0];
                var increase = float.Parse(split[1]);

                switch (vector)
                {
                    case "forward":
                        position.X += increase;
                        break;
                    case "down":
                        position.Y += increase;
                        break;
                    case "up":
                        position.Y -= increase;
                        break;
                }
            }

            Console.WriteLine($"Part 1: {position.X * position.Y}");
        }

        public void RunPart2()
        {
            var horizontal = 0;
            var aim = 0;
            var depth = 0;

            using var reader = new StreamReader("Inputs/Day2.txt");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var split = line.Split(' ');

                var vector = split[0];
                var increase = int.Parse(split[1]);

                switch (vector)
                {
                    case "forward":
                        horizontal += increase;
                        if (aim > 0.0f)
                            depth += (aim * increase);
                        break;
                    case "down":
                        aim += increase;
                        break;
                    case "up":
                        aim -= increase;
                        break;
                }
            }

            Console.WriteLine($"Part 2: {horizontal * depth}");
        }
    }
}
