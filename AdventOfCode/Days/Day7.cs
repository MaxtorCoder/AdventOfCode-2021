namespace AdventOfCode.Days
{
    public class Day7 : IDay
    {
        public object RunPart1()
        {
            var input = File.ReadAllLines("Inputs/Day7.txt")[0]
                .Split(',')
                .Select(int.Parse);

            var sortedNumbers = input.OrderBy(x => x);
            var halfIndex = input.Count() / 2;
            var median = 0.0;

            if ((input.Count() % 2) == 0)
                median = (sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2;
            else
                median = sortedNumbers.ElementAt(halfIndex);

            var fuelCount = 0;
            foreach (var position in input)
                fuelCount += Math.Abs(position - (int)median);

            return fuelCount;
        }

        public object RunPart2()
        {
            var input = File.ReadAllLines("Inputs/Day7.txt")[0]
                 .Split(',')
                 .Select(int.Parse)
                 .ToList();

            var average = input.Average();
            var step = Math.Floor(average);

            var fuelCount = 0;
            foreach (var position in input)
                fuelCount += GetFuel(Math.Abs(position - (int)step));

            return fuelCount;
        }

        private int GetFuel(int n) => (n * (n + 1)) / 2;
    }
}
