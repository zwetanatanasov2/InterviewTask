using System.Text;

public class ProgressGenerateRandomString
{
        private readonly string chars = "0123456789abcdefghijklmnopqrstuvwxyz!@#$% ";
        private StringBuilder output = new StringBuilder();
        private Random random = new Random();

    public string GenerateRandomString(int stringLength)
    {
        if (stringLength < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stringLength), "String length must be non-negative.");
        }

        for (int i = 0; i < stringLength; i++)
        {
            output.Append(chars[random.Next(chars.Length)]);
        }

        string randomString = output.ToString();
        return randomString;
    }
}