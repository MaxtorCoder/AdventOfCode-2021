namespace AdventOfCode;

public static class Extensions
{
    public static string ReplaceAt(this string input, int index, char newChar)
    {
        if (input == null)
            throw new ArgumentNullException("Input is null");

        var chars = input.ToCharArray();
        chars[index] = newChar;
        return new(chars);
    }
}
