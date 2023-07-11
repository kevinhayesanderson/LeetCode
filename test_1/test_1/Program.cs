internal class Program
{
    private static void Main(string[] args)
    {
        Test_1 test_1 = new Test_1();

        //var res = test_1.NoOfDigits(456);

        var res = test_1.IsPalindrome(45654);

        Console.WriteLine(res);
    }
}

internal class Test_1
{
    public bool IsPalindrome(int n) //θ(no of digits in n)
    {
        int rev = 0;
        int temp = n;
        while (temp != 0)
        {
            int lastDigit = temp % 10;
            rev = rev * 10 + lastDigit;
            temp = temp / 10;
        }
        return rev == n;
    }

    public int NoOfDigits(int n) //θ(no of digits in n)
    {
        int res = 0;
        while (n > 0)
        {
            n = n / 10;
            res++;
        }
        return res;
    }

    public int FactorialRecursive(int n) //θ(n) //Axillary space θ(n)
    {
        if (n == 0) return 1;
        return n * FactorialRecursive(n - 1);
    }

    public int FactorialIterative(int n) //θ(n) //Axillary space θ(1) //better than recursive
    {
        int res = 1;
        for (int i = 2; i <= n; i++)
        {
            res = res * i;
        }
        return res;
    }

    //causes overflow exception
    public int TrailingZerosInFactorial_Naive(int n) //θ(n) //Axillary space θ(1)
    {
        int factorial = 1;
        for (int i = 2; i < n; i++)
        {
            factorial = factorial * i;
        }
        int res = 0;
        while (factorial % 10 == 0)
        {
            res++;
            factorial = factorial / 10;
        }
        return res;
    }

    //A trailing zero is always produced by prime factors 2 and 5.
    //Our task is done if we can count the number of 5s and 2s.
    //n = 5: There is one 5 and 3 2s in prime factors of 5! (2 * 2 * 2 * 3 * 5). So a count of trailing 0s is 1.
    //count of 5 in prime factors is less than  or equal to 2, so count 5 alone
    public int TrailingZerosInFactorial_Efficient(int n) //θ(n) //Axillary space θ(1)
    {
        int factorial = 1;
        for (int i = 2; i < n; i++)
        {
            factorial = factorial * i;
        }
        int res = 0;
        while (factorial % 10 == 0)
        {
            res++;
            factorial = factorial / 10;
        }
        return res;
    }
}