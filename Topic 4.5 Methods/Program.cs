using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Topic_4._5_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am a program for drawing ACII art and telling knock-knock jokes");
            while (true){
                Console.WriteLine("Enter [1] for ACII art or [2] for a knock knock joke");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        asciiArt();
                        break;

                    case "2":
                        knockKnock();
                        break;

                    default:
                        Console.WriteLine("Not a valid Input!");
                        break;
                }
            }
        }

        static void knockKnock()
        {
            Console.WriteLine("\nKnock Knock...");
            Console.ReadLine();
            Console.WriteLine("Cow says");
            Console.ReadLine();
            Console.WriteLine("No, Cow says moo!");

            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadLine();
        }

        static void asciiArt()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a drawing from the following: Alien, Cards, Eienstein, AtAt");
                string response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "ALIEN":
                        drawArt(@"Alien.txt");
                        break;
                    case "CARDS":
                        drawArt(@"PlayingCards.txt");
                        break;
                    case "EIENSTEIN":
                        drawArt(@"Eienstein.txt");
                        break;
                    case "ATAT":
                        drawArt(@"ATAT.txt");
                        break;
                    default:
                        Console.WriteLine("Not a valid Input!");
                        break;
                }
                break;
            }
        }

        public static List<int> coordPrompt()
        {
            string[] prompts = { "X Coordinate:", "Y Coordinate:" };
            List<int> coords = new List<int>();

            Console.WriteLine("Choose coordinates for the drawing");

            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(prompts[i]);
                    string response = Console.ReadLine();
                    if (int.TryParse(response, out int num))
                    {
                        coords.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid input!");
                        i--;
                    }
                }
                break;
            }
            return coords;
        }
        static void drawArt(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<int> coords = coordPrompt();

            coords[1] = coords[1] + Console.CursorTop;
            Console.SetCursorPosition(coords[0], coords[1]);

            foreach (string line in lines)
            {
                Console.SetCursorPosition(coords[0], Console.CursorTop);
                Thread.Sleep(100);
                Console.WriteLine(line);
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}
