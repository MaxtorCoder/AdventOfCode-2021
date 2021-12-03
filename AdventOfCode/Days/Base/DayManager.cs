using System.Reflection;

namespace AdventOfCode.Days;

public static class DayManager
{
    private static readonly Dictionary<string, IDay> _days = new();

    public static void Initialize()
    {
        _days.Clear();

        var assembly = Assembly.GetEntryAssembly();
        foreach (var type in assembly.GetTypes())
        {
            if (!typeof(IDay).IsAssignableFrom(type) || type == typeof(IDay))
                continue;

            var day = Activator.CreateInstance(type) as IDay;
            _days.Add(type.Name, day);
        }
    }

    public static void DisplayDays()
    {
        Console.WriteLine( "---------------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"Found {_days.Count} day(s), please select one");
        Console.WriteLine();

        foreach (var (day, _) in _days)
            Console.WriteLine($" - {day}");

        Console.WriteLine();
        Console.WriteLine( "---------------------------------------------");
    }

    public static IDay GetDay(string day)
        => _days.TryGetValue(day, out var dayInfo) ? dayInfo : null;
}
