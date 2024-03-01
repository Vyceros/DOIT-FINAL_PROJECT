namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();

            bool exitCalc = false;

            while (!exitCalc)
            {
                Console.WriteLine("Choose an operation");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter nums to add: ");
                        double[] addNumbers = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
                        Console.WriteLine("result: " + calculator.Add(addNumbers));
                        break;
                    case "2":
                        Console.Write("Enter nums to subtract: ");
                        double[] subtractNumbers = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
                        Console.WriteLine("result: " + calculator.Substract(subtractNumbers));
                        break;
                    case "3":
                        Console.Write("Enter nums to multiply: ");
                        double[] multiplyNumbers = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
                        Console.WriteLine("Result: " + calculator.Multiply(multiplyNumbers));
                        break;
                    case "4":
                        Console.Write("Enter nums to divide: ");
                        double[] divideNumbers = Array.ConvertAll(Console.ReadLine().Split(' '), Double.Parse);
                        try
                        {
                            Console.WriteLine("Result: " + calculator.Divide(divideNumbers));
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "5":
                        exitCalc = true;
                        Console.WriteLine("Quitting.");
                        break;
                    default:
                        Console.WriteLine($"That is not a valid option. Enter numbers 1 to 5");
                        break;
                }
            }

        }

        class Calculator
        {
            public Calculator()
            {

            }
            public double Add(params double[] numbers)
            {
                double result = 0;
                foreach (int i in numbers)
                {
                    result += i;
                }
                return result;
            }

            public double Substract(params double[] numbers)
            {
                if (numbers == null || numbers.Length == 0)
                {
                    throw new ArgumentException("There's nothing to substract");
                }

                double result = numbers[0]; 
                for (int i = 1; i < numbers.Length; i++)
                {
                    result -= numbers[i]; 
                }
                return result;
            }

            public double Multiply(params double[] numbers)
            {
                int result = 1;
                foreach (int i in numbers)
                {
                    result *= i;
                }
                return result;
            }

            public double Divide(params double[] numbers)
            {
                double result = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] == 0)
                    {
                        throw new DivideByZeroException("Can't divide by zero.");
                    }
                    result /= numbers[i];
                }
                return result;
            }
        }
    }
}
