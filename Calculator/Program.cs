namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator calc = new Calculator();
            Console.WriteLine(calc.Multiply(5, 5, 5, 5));
            Console.WriteLine(calc.Add(4,5,6,7,8,9,0,10,14,15,16));
            Console.WriteLine(calc.Divide(5,2));
            Console.WriteLine(calc.Substract(10 - 3 - 2 - 7));
        }

        class Calculator
        {
            public Calculator()
            {

            }
            public int Add(params int[] numbers)
            {
                int result = 0;
                foreach (int i in numbers)
                {
                    result += i;
                }
                return result;
            }

            public int Substract(params int[] numbers)
            {
                if (numbers == null || numbers.Length == 0)
                {
                    throw new ArgumentException("There's nothing to substract");
                }

                int result = numbers[0]; 
                for (int i = 1; i < numbers.Length; i++)
                {
                    result -= numbers[i]; 
                }
                return result;
            }

            public int Multiply(params int[] numbers)
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
                for (int i = 0; i < numbers.Length - 1; i++)
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
