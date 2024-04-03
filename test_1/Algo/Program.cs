namespace Algo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class StringAlgo
    {
        public static bool IsUppercase(string s) => s.All(char.IsUpper);

        public static bool IsLowercase(string s) => s.All(char.IsLower);

        public static bool IsPasswordComplex(string s) => s.Any(char.IsUpper)
                                                          && s.Any(char.IsLower)
                                                          && s.Any(char.IsDigit);

        public static string NormalizeString(string input) => input.ToLower().Trim().Replace(",", "");

        public static bool IsAtEvenIndex(string input, char item)
        {
            for (int i = 0; i < input.Length; i += 2)
            {
                if (input[i] == item) return true;
            }
            return false;
        }
    }

    public abstract class baseclass
    {
        public virtual string GetName()
        {
            return nameof(baseclass);
        }
    }

    public class childclass : baseclass
    {
        public new string GetName()
        {
            return nameof(baseclass);
        }
    }
}