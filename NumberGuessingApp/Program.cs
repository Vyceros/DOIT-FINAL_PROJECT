namespace NumberGuessingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            bool playAgain = true;
            int guess;
            int number;
            int guesses;
            string cont;

            while (playAgain)
            {
                guess = 0;
                guesses = 0;
                number = random.Next(1, 100);

                while (number != guess)
                {
                    Console.WriteLine("\nPick a number between 1 and 100.");
                    guess = int.Parse(Console.ReadLine());
                    Console.WriteLine($"\nYou guessed:{guess} ");

                    if (guess > number)
                    {
                        Console.WriteLine($"\n{guess} is too high");
                    }
                    else if (guess < number)
                    {
                        Console.WriteLine($"\n{guess} is too low");
                    }
                    guesses++;
                }
                Console.WriteLine($"{guess} is correct!\n" +
                    $"You win after {guesses} tries.");

                Console.WriteLine("\nWould you like to continue playing? Yes/No");
                cont = Console.ReadLine();
                cont.ToLower();

                if (cont == "yes")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }
            Console.WriteLine("\nGood game.");
        }
    }
}

