using System.Diagnostics;

namespace AdventOfCode.Days
{
    public class Day4 : IDay
    {
        readonly List<Board> _boards = new();

        public void RunPart1()
        {
            var lines = File.ReadAllLines("Inputs/Day4.txt");

            var sequences = lines[0].Split(',');

            for (var i = 2; i < lines.Length; i += 5)
            {
                var board = new Board();
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    _boards.Add(board);
                    ++i;
                }

                var boardEntries = new string[5, 5];

                for (var j = 0; j < 5; ++j)
                {
                    var initEntries = lines[i + j].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (var k = 0; k < 5; ++k)
                    {
                        boardEntries[j, k] = initEntries[k];
                    }
                }

                board.Init(boardEntries);
            }

            foreach (var sequence in sequences)
            {
                foreach (var board in _boards)
                {
                    board.MarkSequence(sequence);
                    if (board.HasBingo())
                    {
                        var intSequence = int.Parse(sequence);
                        var sumUnmarked = board.GetUnmarkedEntries().Sum();

                        Console.WriteLine($"Part 1: {intSequence} * {sumUnmarked} = {intSequence * sumUnmarked}");
                        return;
                    }
                }
            }
        }

        public void RunPart2()
        {
            var lines = File.ReadAllLines("Inputs/Day4.txt");

            var sequences = lines[0].Split(',');

            var completedBoards = new List<Board>();
            var lastSequence = "";

            foreach (var sequence in sequences)
            {
                foreach (var board in _boards)
                {
                    if (board.HasBingo())
                        continue;

                    board.MarkSequence(sequence);
                    if (board.HasBingo() && !completedBoards.Contains(board))
                    {
                        completedBoards.Add(board);
                        lastSequence = sequence;
                    }
                }
            }

            var lastBoard = completedBoards.Last();

            var intSequence = int.Parse(lastSequence);
            var sumUnmarked = lastBoard.GetUnmarkedEntries().Sum();

            Console.WriteLine($"Part 2: {intSequence} * {sumUnmarked} = {intSequence * sumUnmarked}");
        }
    }

    public class Board
    {
        readonly Dictionary<(int X, int Y), (string Entry, bool Marked)> _entries = new();

        public void Init(string[,] boardEntries)
        {
            for (var x = 0; x < 5; ++x)
            {
                for (var y = 0; y < 5; ++y)
                {
                    var entry = boardEntries[x, y];
                    _entries.Add((x, y), (entry, false));
                }
            }
        }

        public void MarkSequence(string sequence)
        {
            for (var x = 0; x < 5; ++x)
            {
                for (var y = 0; y < 5; ++y)
                {
                    if (_entries[(x, y)].Entry == sequence)
                    {
                        _entries[(x, y)] = (sequence, true);
                        return;
                    }
                }
            }
        }

        public bool HasBingo()
        {
            for (var x = 0; x < 5; ++x)
            {
                var horizontalMarked = 0;
                var verticalMarked = 0;

                for (var y = 0; y < 5; ++y)
                {
                    if (_entries[(y, x)].Marked)
                        horizontalMarked++;
                    if (_entries[(x, y)].Marked)
                        verticalMarked++;
                }

                if (horizontalMarked == 5 || verticalMarked == 5)
                    return true;
            }

            return false;
        }

        public List<int> GetUnmarkedEntries()
        {
            var unmarkedEntries = new List<int>();

            for (var x = 0; x < 5; ++x)
            {
                for (var y = 0; y < 5; ++y)
                {
                    if (!_entries[(x, y)].Marked)
                    {
                        unmarkedEntries.Add(int.Parse(_entries[(x, y)].Entry));
                    }
                }
            }

            return unmarkedEntries;
        }
    }
}
