public class Program
{
    /// <summary>
    /// Delegate - function as a parameter to another function/itself
    /// type-safe function pointer use in callback methods
    /// </summary>
    
    private delegate bool IsNumberDelegate(int number);
    static void Main(string[] args)
    {
        var number = new Random().Next();

        IsNumberDelegate isOddDelegate = IsOdd;
        IsNumberDelegate isEvenDelegate = IsEven;
        Calculate(number, isOddDelegate, isEvenDelegate);
        
        //invoke use for null-check
        IsNumberDelegate isNullDelegate = null;
        isNullDelegate?.Invoke(number);
    }

    private static bool IsOdd(int number) => number % 2 == 1;
    
    private static bool IsEven(int number) => number % 2 == 0;
    private static void Calculate(int number, IsNumberDelegate oddDelegate, IsNumberDelegate evenDelegate)
    {
        Console.WriteLine($"before: {number}");
        
        if (oddDelegate(number))
        {
            number++;
            Console.WriteLine($"after odd: {number}");
        }

        if (evenDelegate(number))
        {
            number--;
            Console.WriteLine($"after even: {number}");
        }
    }
}