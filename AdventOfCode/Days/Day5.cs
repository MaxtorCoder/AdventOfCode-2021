namespace AdventOfCode.Days
{
    public class Day5 : IDay
    {
        readonly Dictionary<(int X, int Y), int> _board = new();

        public void RunPart1()
        {
            var lines = File.ReadAllLines("Inputs/Day5.txt");

            var maxNumber = 0;

            foreach (var line in lines)
            {
                if (line.StartsWith("//") || string.IsNullOrWhiteSpace(line))
                    continue;

                var split = line.Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length > 4)
                    continue;

                var x1 = int.Parse(split[0]);
                var y1 = int.Parse(split[1]);
                var x2 = int.Parse(split[2]);
                var y2 = int.Parse(split[3]);

                MarkCoords(x1, x2, y1, y2);

                if (maxNumber < x1)
                    maxNumber = x1;
                else if (maxNumber < x2)
                    maxNumber = x2;

                if (maxNumber < y1)
                    maxNumber = y1;
                else if (maxNumber < y2)
                    maxNumber = y2;
            }

            var intersectAbove2 = 0;
            for (var x = 0; x <= maxNumber; ++x)
            {
                for (var y = 0; y <= maxNumber; ++y)
                {
                    if (_board.ContainsKey((y, x)))
                    {
                        if (_board[(y, x)] >= 2)
                            ++intersectAbove2;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Part 1: {intersectAbove2}");
        }

        public void RunPart2()
        {
            var lines = File.ReadAllLines("Inputs/Day5.txt");

            var maxNumber = 0;

            foreach (var line in lines)
            {
                if (line.StartsWith("//") || string.IsNullOrWhiteSpace(line))
                    continue;

                var split = line.Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length > 4)
                    continue;

                var x1 = int.Parse(split[0]);
                var y1 = int.Parse(split[1]);
                var x2 = int.Parse(split[2]);
                var y2 = int.Parse(split[3]);

                MarkAllCoords(x1, x2, y1, y2);

                if (maxNumber < x1)
                    maxNumber = x1;
                else if (maxNumber < x2)
                    maxNumber = x2;

                if (maxNumber < y1)
                    maxNumber = y1;
                else if (maxNumber < y2)
                    maxNumber = y2;
            }

            var intersectAbove2 = 0;
            for (var x = 0; x <= maxNumber; ++x)
            {
                for (var y = 0; y <= maxNumber; ++y)
                {
                    if (_board.ContainsKey((y, x)))
                    {
                        if (_board[(y, x)] >= 2)
                            ++intersectAbove2;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Part 2: {intersectAbove2}");
        }

        private void MarkCoords(int x1, int x2, int y1, int y2)
        {
            // Ignore diagonal coords
            if ((x1 == x2 && y1 != y2) || (x1 != x2 && y1 == y2))
            {
                var xCount = Math.Abs(x1 - x2);
                var yCount = Math.Abs(y1 - y2);

                for (var i = 0; i <= xCount; ++i)
                {
                    if (x1 > x2)
                        MarkCoordsInBoard(x1 - i, y1);
                    else if (x1 < x2)
                        MarkCoordsInBoard(x1 + i, y1);
                }
                for (var i = 0; i <= yCount; ++i)
                {
                    if (y1 > y2)
                        MarkCoordsInBoard(x1, y1 - i);
                    else if (y1 < y2)
                        MarkCoordsInBoard(x1, y1 + i);
                }
            }
        }

        private void MarkAllCoords(int x1, int x2, int y1, int y2)
        {
            var xCount = Math.Abs(x1 - x2);
            var yCount = Math.Abs(y1 - y2);

            for (int i = 0, j = 0; i <= xCount && j <= yCount; ++i, ++j)
            {
                if (x1 > x2 && y1 > y2)
                    MarkCoordsInBoard(x1 - i, y1 - j);
                else if (x1 > x2 && y1 < y2)
                    MarkCoordsInBoard(x1 - i, y1 + j);
                else if (x1 < x2 && y1 > y2)
                    MarkCoordsInBoard(x1 + i, y1 - j);
                else if (x1 < x2 && y1 < y2)
                    MarkCoordsInBoard(x1 + i, y1 + j);
            }
        }

        private void MarkCoordsInBoard(int x, int y)
        {
            if (!_board.ContainsKey((x, y)))
                _board.Add((x, y), 0);
            _board[(x, y)]++;
        }
    }
}
