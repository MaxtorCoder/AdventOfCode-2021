namespace AdventOfCode.Days
{
    internal class Day6 : IDay
    {
        public object RunPart1()
        {
            var line = File.ReadAllLines("Inputs/Day6.txt")[0]
                .Split(',')
                .Select(int.Parse);

            var ages = new List<int>();
            foreach (var age in line)
                ages.Add(age);

            for (var day = 1; day <= 80; ++day)
            {
                for (var i = 0; i < ages.Count; ++i)
                {
                    if (ages[i] == 0)
                    {
                        ages.Add(9);
                        ages[i] = 6;

                        continue;
                    }

                    --ages[i];
                }
            }

            return ages.Count;
        }

        public object RunPart2()
        {
            var line = File.ReadAllLines("Inputs/Day6.txt")[0]
                .Split(',')
                .Select(long.Parse);

            var ageList = new long[9];
            for (var i = 0; i < ageList.Length; ++i)
                ageList[i] = 0;

            foreach (var age in line)
                ++ageList[age];

            for (var day = 1; day <= 256; ++day)
            {
                var born = ageList[0];

                for (var i = 0; i < ageList.Length - 3; ++i)
                    ageList[i] = ageList[i + 1];

                ageList[6] = ageList[7] + born;
                ageList[7] = ageList[8];
                ageList[8] = born;
            }

            return ageList.Sum();
        }
    }
}
