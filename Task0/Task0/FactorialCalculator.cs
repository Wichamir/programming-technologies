namespace Task0;

public class FactorialCalculator
{
    public int Calculate(int n)
    {
        if (n < 0)
        {
            throw new Exception("Provided negative integer for factorial function.");
        }

        int result = 1;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}