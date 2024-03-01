namespace Task0
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new FactorialCalculator();
            Console.Write("Factorial of: ");
            var input = Console.ReadLine();
            var number = int.Parse(input);
            Console.WriteLine("Factorial of {0} is {1}.", number, calculator.Calculate(number));
        }
    }
}