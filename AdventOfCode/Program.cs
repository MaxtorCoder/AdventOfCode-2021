using AdventOfCode.Days;
using System.Diagnostics;

namespace AdventOfCode;

class Program
{
    static void Main(string[] args)
    {
        DayManager.Initialize();
        DayManager.DisplayDays();

        IDay day = null;

        while (day == null)
        {
            Console.Write("Input day: ");
            var dayInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dayInput))
                continue;

            dayInput = dayInput.ReplaceAt(0, char.ToUpper(dayInput[0]));

            day = DayManager.GetDay(dayInput);
        }

        Console.WriteLine();

        var watch = new Stopwatch();
        watch.Start();

        var part1 = day.RunPart1();

        watch.Stop();
        Console.WriteLine($"Part 1 finished in {watch.Elapsed}");

        watch.Restart();

        var part2 = day.RunPart2();

        watch.Stop();
        Console.WriteLine($"Part 2 finished in {watch.Elapsed}");

        Console.WriteLine($"Part 1: {part1}");
        Console.WriteLine($"Part 2: {part2}");
    }
}
