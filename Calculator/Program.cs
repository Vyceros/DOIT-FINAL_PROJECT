namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();

            


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
