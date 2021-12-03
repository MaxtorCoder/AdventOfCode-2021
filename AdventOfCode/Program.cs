using AdventOfCode.Days;

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

        day.RunPart1();
        day.RunPart2();
    }
}
