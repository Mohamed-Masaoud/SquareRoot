class SquareRootCalculator
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    static void Main()
    {
        bool continueCalculating = true;
        while (continueCalculating)
        {
            Console.WriteLine("\n--- Square Root Calculation ---");
            double Y = GetPositiveNumberFromUser();
            CalculateSquareRoot(Y);
            continueCalculating = AskToContinue();
        }
        Console.WriteLine("\n--- Program Ended ---");
    }

    /// <summary>
    /// Prompts the user to input a number to calculate the square root of and validates the input.
    /// </summary>
    /// <returns>A positive number entered by the user.</returns>
    static double GetPositiveNumberFromUser()
    {
        double Y;
        while (true)
        {
            Console.Write("\nEnter a positive number to calculate its square root: ");
            if (double.TryParse(Console.ReadLine(), out Y) && Y > 0)
            {
                return Y;
            }
            Console.WriteLine("Invalid input. Please enter a number greater than 0.");
        }
    }

    /// <summary>
    /// Calculates and displays the square root of a given number using the Babylonian method.
    /// </summary>
    /// <param name="Y">The number for which to calculate the square root.</param>
    static void CalculateSquareRoot(double Y)
    {
        const double MAX_ERROR = 0.001;
        const int MAX_ITERATIONS = 100;

        double squareRoot = Math.Pow(10, NumberOfDigits(Y) - 1);

        double previousValue;
        int iteration = 0;
        double absoluteError;

        // Iterative calculation of square root
        do
        {
            previousValue = squareRoot;
            squareRoot = 0.5 * (previousValue + Y / previousValue);
            absoluteError = Math.Abs(squareRoot * squareRoot - Y);
            iteration++;

        } while (absoluteError > MAX_ERROR && iteration < MAX_ITERATIONS);

        Console.WriteLine($"\nSquare root of {Y} = {squareRoot}");
        Console.WriteLine($"Number of Iterations = {iteration}");
    }

    /// <summary>
    /// Asks the user whether they would like to continue and validates the response.
    /// </summary>
    /// <returns>True if the user wants to continue. Otherwise, false.</returns>
    static bool AskToContinue()
    {
        while (true)
        {
            Console.Write("\nWould you like to calculate another square root? (y/n): ");
            var response = Console.ReadLine();

            // Validate the response
            if (response != null)
            {
                response = response.Trim().ToLower();
                if (response == "y")
                {
                    return true;
                }
                else if (response == "n")
                {
                    return false;
                }
            }
            Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
        }
    }

    /// <summary>
    /// number of digits in a number
    /// </summary>
    /// <param name="Y">number to check the number of digits</param>
    /// <returns>number of digits</returns>
    static int NumberOfDigits(double Y)
    {
        return Y.ToString().Replace(".", "").Length;
    }
}
