﻿//¹²³⁴⁵⁶⁷⁸⁹⁰
//₀₁₂₃₄₅₆₇₈₉
//
//ᵃᵇᶜᵈᵉᶠᵍʰⁱʲᵏˡᵐⁿᵒᵖʳˢᵗᵘᵛʷˣʸᶻ
//ₐ ₑ ₕ ᵢ ⱼ ₖ ₗ ₘ ₙ ₒ ₚ ᵣ ₛ ₜ ᵤ ᵥ ₓ

using System.Net.NetworkInformation;

internal class Program
{
    private static void Main(string[] args)
    {
        Test_1 test_1 = new Test_1();

        //var res = test_1.NoOfDigits(456);

        //var res = test_1.IsPalindrome(45654);

        //var res = test_1.GCDorHCF_Efficient_2(20, 28);

        var res = test_1.PrimeFactors_Efficient_1(84);
        res.ForEach(Console.WriteLine);
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
        for (int i = 5; i <= n; i = i * 5)
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
        while (res > 0)
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

    /// <summary>
    /// The basic approach is to find the maximum of both numbers, then iterate from that number, till we find a number that is completely divisible by both numbers.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int LCM_Naive(int a, int b) //θ(a*b - max(a,b))
    {
        int res = Math.Max(a, b);
        while (true)
        {
            if (res % a == 0 && res % b == 0)
            {
                return res;
            }
            res++;
        }
    }

    /// <summary>
    /// An efficient solution is based on the below formula for LCM of two numbers ‘a’ and ‘b’.
    /// a x b = LCM(a, b) * GCD(a, b)
    /// LCM(a, b) = (a x b) / GCD(a, b)
    /// we calculate GCD using, Optimized Euclidean Algorithm.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int LCM_Efficient(int a, int b)//θ(log(min(a, b))
    {
        return a * b / gcd(a, b);
    }

    private int gcd(int a, int b) //θ(log(min(a,b)))
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }

    /// <summary>
    /// Iterate from 2 to  (n-1) and check if any number in this range divides n.
    /// If the number divides n, then it is not a prime number.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsPrime_Naive(int n) //θ(n)
    {
        if (n == 1) return false;
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// If (x,y) is a pair
    /// x*y=n
    /// And if x<= y
    /// x*x <= n
    /// x<=√n
    /// start from 2, traverse till √n, if we find the divisor, the n is not prime otherwise it is prime
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsPrime_Efficient_1(int n) //θ(sqrt(n))
    {
        if (n == 1) return false;
        ////for (int i = 2; i < Math.Sqrt(n); i++)
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// For large number, √n is also large.
    /// adding two extra checks,
    /// n%2 == 0, n is not prime, all the even no's can be skipped
    /// n%3 == 0, n is not prime,
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsPrime_Efficient_2(int n) //θ(sqrt(n))
    {
        if (n == 1 || n == 2 || n == 3 || n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i = i + 6)//we iterate from 5 to sqrt(n), increment the value by 6 [because any prime can be expressed as 6n+1 or 6n-1].
        {
            if (n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Iterate from 2 to  (n-1) and check if the number is prime.
    /// If the number is prime, then divide the given number by this number, till it remains completely divisible.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> PrimeFactors_Naive(int n)//θ(nlogn)
    {
        var res = new List<int>();
        for (int i = 2; i < n; i++)
        {
            if (isPrime(i))
            {
                int x = i;
                while (n % x == 0)
                {
                    res.Add(i);
                    x = x * i;
                }
            }
        }
        return res;
    }

    private bool isPrime(int n)
    {
        if (n == 1 || n == 2 || n == 3 || n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i = i + 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Iterate through all numbers from 2 to square root of n and for every number check if it divides n [because if a number is expressed as n = xy and any of the x or y is greater than the root of n, the other must be less than the root value].
    /// Repetitively divide n by the number till it remains completely divisible, and print the values.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> PrimeFactors_Efficient_1(int n)//θ(sqrt(n))
    {
        var res = new List<int>();
        if (n <= 1) return res;
        for (int i = 2; i * i <= n; i++)
        {
            while (n % i == 0)
            {
                res.Add(i);
                n = n / i;
            }
        }
        if (n > 1)
            res.Add(n);
        return res;
    }

    /// <summary>
    /// We will deal with a few numbers such as 1, 2, and 3, and the numbers which are divisible by 2 and 3 in separate cases.
    /// For the remaining numbers, we iterate from 5 to sqrt(n) and check for each iteration whether(that value) or(that value + 2) divides n or not and increment the value by 6 [because any prime can be expressed as 6n+1 or 6n-1].
    /// If we find any number that divides, then, repetitively divide n by the number till it remains completely divisible, and print the values.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> PrimeFactors_Efficient_2(int n)//θ(sqrt(n))
    {
        var res = new List<int>();
        if (n <= 1) return res;
        while (n % 2 == 0)
        {
            res.Add(2);
            n = n / 2;
        }
        while (n % 3 == 0)
        {
            res.Add(3);
            n = n / 3;
        }
        for (int i = 5; i * i <= n; i = i + 6)
        {
            while (n % i == 0)
            {
                res.Add(i);
                n = n / i;
            }
            while (n % (i + 2) == 0)
            {
                res.Add(i + 2);
                n = n / (i + 2);
            }
        }
        if (n > 3)
            res.Add(n);
        return res;
    }

    /// <summary>
    /// A Naive Solution would be to iterate all the numbers from 1 to n, checking if that number divides n
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> Divisors_Naive(int n)//θ(n) 
    {
        var res = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
                res.Add(i);
        }
        return res;
    }

    /// <summary>
    /// All the divisors are present in pairs.
    /// For example if n = 100, then the various pairs of divisors are: (1,100), (2,50), (4,25), (5,20), (10,10)
    /// Using this fact we could speed up our program significantly. We, however, have to be careful if there are two equal divisors as in the case of (10, 10). In such case, we’d print only one of them. 
    /// We iterate through all numbers from 1 to square root of n in this case.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> Divisors_Efficient_1(int n)//θ(sqrt(n)) 
    {
        var res = new List<int>();
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                res.Add(i);
                if (i != n / i) // for perfect square, Eg: 25 the pair might be (5,5), we won't add 5 two times
                    res.Add(n / i);
            }
        }
        return res;
    }

    /// <summary>
    /// We want to print the divisors in sorted order.
    /// The idea is to 1st print all divisors from 1 (inclusive) to square root n(exclusive)
    /// Then, print all divisors from square root n(inclusive) to n(inclusive)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public List<int> Divisors_Efficient_2(int n)//θ(sqrt(n)) 
    {
        var res = new List<int>();
        int i;
        for (i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                res.Add(i);
            }
        }
        for (; i >= 1; i--)
        {
            if (n % i == 0)
            {
                res.Add(n/i);
            }
        }
        return res;
    }
}