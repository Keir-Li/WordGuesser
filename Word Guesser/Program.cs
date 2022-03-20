using System;
using System.Threading;

namespace Word_Guesser
{
    internal class Program
    {
        static void Main(string[] args)
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

            // introduction
            Console.WriteLine("What is your name?");

            // set users name into name variable
            string playerName = Console.ReadLine();

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
                    Console.WriteLine("That wasn't an option. Enter again... write either 'EASY' or 'HARD'");
                    pickedDifficulty = Console.ReadLine(); //
                }
            }
            while (!difficultySet);


            Console.WriteLine("Hello {0}, let's play Word Guesser", playerName);
            Thread.Sleep(1000);
            Console.Clear();

            // loading game
            ProgressBarCiz(2, 1, 100, 0, ConsoleColor.White);

            Console.Clear();

            // change colour of text
            Console.ForegroundColor = ConsoleColor.Green;

            // write app information
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appCreator);

            // reset colour of text
            Console.ResetColor();

            // set correct word
            string correctWord = "Cave";
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
                        // change colour of text & print wrong guess message
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong word, please try again.");
                        Console.WriteLine(easyWordHint);
                        Console.ResetColor();
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
                        // change colour of text & print wrong guess message
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong word, please try again");
                        Console.WriteLine(hardWordHint);
                        Console.ResetColor();
                    };

                }
            }


            // success end game
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");

            // write app information
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appCreator);



        }

        public static void ProgressBarCiz(int sol, int ust, int deger, int isaret, ConsoleColor color)
        {
            char[] symbol = new char[5] { '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };
            int maxBarSize = Console.BufferWidth - 1;
            int barSize = deger;
            decimal f = 1;
            if (barSize + sol > maxBarSize)
            {
                barSize = maxBarSize - (sol + 5); // first 5 character "%100 "
                f = (decimal)deger / (decimal)barSize;
            }
            Console.CursorVisible = false;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(sol + 5, ust);
            for (int i = 0; i < barSize + 1; i++)
            {
                System.Threading.Thread.Sleep(10);
                Console.Write(symbol[isaret]);
                Console.SetCursorPosition(sol, ust);
                Console.Write("%" + (i * f).ToString("0,0"));
                Console.SetCursorPosition(sol + 5 + i, ust);
            }
            Console.ResetColor();
        }
    }
}
