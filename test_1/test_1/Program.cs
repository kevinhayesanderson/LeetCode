//¹²³⁴⁵⁶⁷⁸⁹⁰
//₀₁₂₃₄₅₆₇₈₉
//
//ᵃᵇᶜᵈᵉᶠᵍʰⁱʲᵏˡᵐⁿᵒᵖʳˢᵗᵘᵛʷˣʸᶻ
//ₐ ₑ ₕ ᵢ ⱼ ₖ ₗ ₘ ₙ ₒ ₚ ᵣ ₛ ₜ ᵤ ᵥ ₓ
internal class Program
{
    private static void Main(string[] args)
    {
        Test_1 test_1 = new Test_1();

        //var res = test_1.NoOfDigits(456);

        //var res = test_1.IsPalindrome(45654);

        var res = test_1.GCDorHCF(20, 28);

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
    // the factors are 5, 25, 125 ..., so we count these factors
    public int TrailingZerosInFactorial_Efficient(int n) //θ(log n) //Axillary space θ(1)
    {
        int res = 0;
        for (int i = 5; i <= n; i=i*5)
        {
            res = res + n / i; //int division always gives floor
        }
        return res;
    }
    // for time complexity
    // where k is the no of iteration
    // 5^K <= n
    // k <= log₅n
    //θ(log n)


    //idea is to find the minimum of the two numbers and then, traverse from the min number to 1.
    public int GCDorHCF_Naive(int a, int b) //θ(min(a,b)) //Axillary space θ(1)//
    {
        int res = Math.Min(a, b);
        while(res>0)
        {
            if (a % res == 0 && b % res == 0)
            {
                break;
            }
            res--;
        }
        return res;
    }


    /// <summary>
    /// Euclidean Approach
    /// The idea of this algorithm is, the GCD of two numbers doesn’t change if the smaller number is subtracted from the bigger number. 
    /// This is the Euclidean algorithm by subtraction. 
    /// It is a process of repeat subtraction, carrying the result forward each time until the result is equal to any one number being subtracted.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int GCDorHCF_Efficient_1(int a, int b)//θ(min(a,b)) //Axillary space θ(1)//
    {
        while (a != b)
        {
            if (a > b)
                a = a - b;
            else
                b = b - a;
        }
        return a;
    }

    /// <summary>
    /// Optimized Euclidean Approach
    /// In this approach, instead of repeatedly subtracting the numbers till both become equal, we can check if one number is a factor of the other.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int GCDorHCF_Efficient_2(int a, int b) //θ(log(min(a,b))) //Axillary space θ(1) 
    {
        if (b == 0)
            return a;
        return GCDorHCF_Efficient_2(b, a % b); //if b<a, (a%b) < b, the remainder is always smaller than b
                                               //if b>a, (a%b) == a, so the first recursive call just swaps the parameter
    }
}