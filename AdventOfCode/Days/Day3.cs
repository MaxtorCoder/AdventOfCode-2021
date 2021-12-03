namespace AdventOfCode.Days
{
    public class Day3 : IDay
    {
        public void RunPart1()
        {
            var lines = File.ReadAllLines("Inputs/Day3.txt");

            var gammaRate = "";
            var epsilonRate = "";
            for (var i = 0; i < 12; ++i)
            {
                var onCount = 0;
                var offCount = 0;

                for (var j = 0; j < lines.Length; ++j)
                {
                    var bit = lines[j][i];
                    if (bit == '1')
                        ++onCount;
                    else
                        ++offCount;
                }

                var commonBit = onCount > offCount ? '1' : '0';
                gammaRate += commonBit;

                var oddBit = onCount < offCount ? '1' : '0';
                epsilonRate += oddBit;
            }

            var gammaRateDec = Convert.ToInt32(gammaRate, 2);
            var episolonRateDec = Convert.ToInt32(epsilonRate, 2);
            Console.WriteLine($"Part 1: {gammaRateDec} * {episolonRateDec} = {gammaRateDec * episolonRateDec}");
        }

        public void RunPart2()
        {
            var lines = File.ReadAllLines("Inputs/Day3.txt");

            var commonStrings = new List<string>(lines);
            var oddStrings = new List<string>(lines);

            for (var i = 0; i < 12; ++i)
            {
                if (commonStrings.Count == 1)
                    break;

                RemoveEntriesWithPosition(i, ref commonStrings);
            }

            for (var i = 0; i < 12; ++i)
            {
                if (oddStrings.Count == 1)
                    break;

                RemoveEntriesWithPosition(i, ref oddStrings, true);
            }

            var num1 = Convert.ToInt32(commonStrings[0], 2);
            var num2 = Convert.ToInt32(oddStrings[0], 2);
            Console.WriteLine($"Part 1: {num1} * {num2} = {num1 * num2}");
        }

        private void RemoveEntriesWithPosition(int position, ref List<string> strings, bool takeOdd = false)
        {
            var listCopy = strings;

            var completedString = "";
            for (var i = 0; i < strings.Count; ++i)
                completedString += strings[i][position];

            var onCount = 0;
            var offCount = 0;
            for (var i = 0; i < completedString.Length; ++i)
            {
                if (completedString[i] == '1')
                    ++onCount;
                else if (completedString[i] == '0')
                    ++offCount;
            }

            var removed = 0;
            if (!takeOdd)
            {
                if (onCount > offCount)
                    removed = listCopy.RemoveAll(x => x[position] == '0');
                else if (offCount > onCount)
                    removed = listCopy.RemoveAll(x => x[position] == '1');
                else
                    removed = listCopy.RemoveAll(x => x[position] == '0');
            }
            else
            {
                if (onCount > offCount)
                    removed = listCopy.RemoveAll(x => x[position] == '1');
                else if (offCount > onCount)
                    removed = listCopy.RemoveAll(x => x[position] == '0');
                else
                    removed = listCopy.RemoveAll(x => x[position] == '1');
            }

            strings = listCopy;
        }
    }
}
