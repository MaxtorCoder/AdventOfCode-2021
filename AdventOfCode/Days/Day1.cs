namespace AdventOfCode.Days;

public class Day1 : IDay
{
    public void RunPart1()
    {
        var values = FileReader.ReadFileSingleLine<int>("Inputs/Day1.txt");

        var increaseCount = 0;
        for (var i = 1; i < values.Length; ++i)
        {
            if (values[i] > values[i - 1])
                ++increaseCount;
        }

        Console.WriteLine($"Part 1: {increaseCount}");
    }

    public void RunPart2()
    {
        var values = FileReader.ReadFileSingleLine<int>("Inputs/Day1.txt");

        // Assemble sliding window
        var slidingWindow = new List<int>();
        for (var i = 0; i < values.Length - 2; ++i)
        {
            var a1 = values[i];
            var a2 = values[i + 1];
            var a3 = values[i + 2];

            slidingWindow.Add(a1 + a2 + a3);
        }

        // Calculate difference
        var increaseCount = 0;
        for (var i = 1; i < slidingWindow.Count; ++i)
        {
            if (slidingWindow[i] > slidingWindow[i - 1])
                ++increaseCount;
        }

        Console.WriteLine($"Part 2: {increaseCount}");
    }
}
