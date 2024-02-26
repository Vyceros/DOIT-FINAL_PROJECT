namespace HangmanApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "apple", "banana", "orange", "grape", "strawberry" };
            Random random = new Random();
            string wordToGuess = words[random.Next(0, words.Length)];
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int maxLives = 8;
            int lives = maxLives;
            bool isGameOver = false;

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Guess the word:");

            while (!isGameOver)
            {
                Console.WriteLine();
                Console.WriteLine("Lives left: " + lives);
                Console.WriteLine("Word: " + string.Join(" ", guessedWord));

                Console.Write("Guess a letter: ");
                char guess = Console.ReadLine().ToLower()[0];

                bool guessedCorrectly = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        guessedCorrectly = true;
                    }
                }

                if (!guessedCorrectly)
                {
                    lives--;
                    Console.WriteLine("Incorrect guess!");
                    if (lives == 0)
                    {
                        Console.WriteLine("Game Over! The word was: " + wordToGuess);
                        isGameOver = true;
                    }
                }
                else if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
                    isGameOver = true;
                }
                else
                {
                    Console.WriteLine("Correct guess!");
                }
            }

            Console.ReadLine();
        }




        public static bool isWordComplete(string randomWord, string[] hiddenWord)
        {
            string newHiddenWord = string.Empty;

            foreach (var item in hiddenWord)
            {
                newHiddenWord += item;
            }

            if (randomWord != newHiddenWord)
            {
                return false;
            }

            return true;

        }

        public static void printOutWord(string[] word)
        {
            string newWord = string.Empty;
            foreach (var item in word)
            {
                newWord += item;
            }
            Console.Write(newWord);
        }

    }
}

