using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Simple Calculator!");
        Console.WriteLine("Available operations: +, -, *, /");
        Console.WriteLine("Enter 'q' to quit.");

        while (true)
        {
            Console.Write("Enter an expression: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            try
            {
                double result = Calculate(input);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static double Calculate(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid input format. Please use 'number operator number'.");
        }

        double operand1 = Convert.ToDouble(parts[0]);
        double operand2 = Convert.ToDouble(parts[2]);
        string operation = parts[1];

        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return operand1 / operand2;
            default:
                throw new ArgumentException("Invalid operator. Supported operators: +, -, *, /");
        }
    }
}
