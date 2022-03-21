using System;
using System.Threading;

namespace Word_Guesser
{
    internal class Program : ProgressBar
    {
        public static object playerNameSet { get; private set; }

        static void Main(string[] args)
        {
            // app information
            AppInfo();

            // greet and ask players name
            PlayerName();

            while (true)
            {

                /// set difficulty
                Console.WriteLine("What difficuly would you like? Enter 'EASY' (4 words) or 'HARD' (6 words) to choose.");
                string pickedDifficulty = Console.ReadLine();
                bool difficultySet = false;

                do
                {
                    if (pickedDifficulty.ToLower() == "easy" || pickedDifficulty.ToLower() == "hard")
                    {
                        difficultySet = true;
                    }
                    else
                    {
                        //if input didn't match options, continue loop
                        // change colour of text, incorrect option & reset colour
                        PrintColourMessage(ConsoleColor.Red, "That wasn't an option. Enter again... write either 'EASY' or 'HARD'");
                        pickedDifficulty = Console.ReadLine(); //
                    }
                }
                while (!difficultySet);


                Console.WriteLine("Hello {0}, let's play Word Guesser", playerNameSet);
                Thread.Sleep(1000);
                Console.Clear();

                // loading game
                AppProgressBar(2, 1, 100, 0, ConsoleColor.White);

                Console.Clear();

                // change colour of text
                Console.ForegroundColor = ConsoleColor.Green;

                // write app information
                AppInfo();

                // reset colour of text
                Console.ResetColor();

                // give player a hint
                string easyWordHint = "Hint: It could be starting with C and found near a cliff edge, could be a word for a retail store, a type of terrain, a small horse, a viscious cat or a piece of wildlife that has branches";
                string hardWordHint = "Hint: It could be another word for year, a hot beverage, a type of habitat, a workplace location or a colour. ";

                //Dictionary of correct easy words
                string[] easyWords = { "Cave", "Shop", "Hill", "Pony", "Lion", "Tree" };

                //Dictionary of correct easy words
                string[] hardWords = { "Annual", "Coffee", "Island", "Office", "Yellow" };


                // set random easy correct word
                Random randomEasyWord = new Random();

                //Create combination of word + number
                string correctEasyWord = $"{easyWords[randomEasyWord.Next(0, easyWords.Length)]}";

                //set randomhard word
                Random randomHardWord = new Random();
                //Create combination of word + number
                string correctHardWord = $"{hardWords[randomHardWord.Next(0, hardWords.Length)]}";


                // initialise guess variable
                string guess = "";

                // ask player for a word guess
                Console.WriteLine("Guess a word... ");

                // initialise difficulty
                if (pickedDifficulty.ToLower() == "easy")
                {
                    // while easy guess is not correct
                    while (guess.ToLower() != correctEasyWord.ToLower())
                    {
                        // get users input
                        string input = Console.ReadLine();

                        // check to see if the input is the same as the correctWord
                        guess = input;
                        if (guess.ToLower() != correctEasyWord.ToLower())
                        {
                            // change colour of text, incorrect guess & reset colour
                            PrintColourMessage(ConsoleColor.Red, "Wrong word, please try again.");
                            Console.WriteLine(easyWordHint);
                        };

                    }
                }
                else
                {
                    // while hard guess is not correct
                    while (guess.ToLower() != correctHardWord.ToLower())
                    {
                        // get users input
                        string input = Console.ReadLine();

                        // check to see if the input is the same as the correctWord
                        guess = input;
                        if (guess.ToLower() != correctHardWord.ToLower())
                        {
                            // change colour of text, incorrect guess & reset colour
                            PrintColourMessage(ConsoleColor.Red, "Wrong word, please try again.");
                            Console.WriteLine(hardWordHint);
                        };

                    }
                }


                // success end game
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");

                // write app information
                AppInfo();

                // ask player if they want to play again
                Console.WriteLine("Play Again? [Y or N]");

                // get answer
                string playerPlayAgain = Console.ReadLine().ToUpper();

                if (playerPlayAgain == "Y")
                {
                    continue;
                }
                else if (playerPlayAgain == "N")
                {
                    return;
                }
                else
                {
                    return;
                }

            }



        }

        static void AppInfo()
        {
            // set app variables
            string appName = "Word Guesser";
            string appVersion = "1.0";
            string appCreator = "Keir Li";

            // change colour of text
            Console.ForegroundColor = ConsoleColor.Green;

            // write app information
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appCreator);

            // reset colour of text
            Console.ResetColor();
        }

        static string PlayerName()
        {
            // introduction
            Console.WriteLine("What is your name?");

            // set users name into name variable
            string playerName = Console.ReadLine();
            playerNameSet = playerName;
            return playerName;
        }

        static void PrintColourMessage(ConsoleColor colour, string message)
        {
            // change colour of text
            Console.ForegroundColor = colour;

            // write app information
            Console.WriteLine(message);

            // reset colour of text
            Console.ResetColor();
        }
    }
}
