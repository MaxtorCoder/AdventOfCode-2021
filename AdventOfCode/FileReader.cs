namespace AdventOfCode;

public static class FileReader
{
    public static T[] ReadFileSingleLine<T>(string dayInput) where T : new()
    {
        var list = new List<T>();

        using (var reader = new StreamReader(dayInput))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var val = (T)Convert.ChangeType(line, typeof(T));
                if (val == null)
                    continue;

                list.Add(val);
            }
        }

        return list.ToArray();
    }
}
