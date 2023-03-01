using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Console.WriteLine("Knock Knock...");
            Console.ReadLine();
            Console.WriteLine("Cow says");
            Console.ReadLine();
            Console.WriteLine("No, Cow says moo!");
        }

        static void asciiArt()
        {
            while (true)
            {
                Console.WriteLine("Choose a drawing from the following: Alien, Cards, ");
                string response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "ALIEN":
                        drawAlien();
                        break;
                    case "CARDS":
                        drawCards();
                        break;
                    default:
                        Console.WriteLine("Not a valid Input!");
                        break;
                }
                break;
            }
        }
        static void drawAlien()
        {
            string[] lines = File.ReadAllLines(@"Alien.txt");
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

            Console.WriteLine(Console.CursorTop);
            coords[1] = coords[1] + Console.CursorTop;

            
            foreach (string line in lines.Select((value, i) => new { i, value }))
            {
                Console.SetCursorPosition(coords[0], coords[1]);
                Console.WriteLine(line);
            }
            Console.ReadLine();
            Console.WriteLine("Alien Drawn"); 
        }
        static void drawCards()
        {
            string[] lines = File.ReadAllLines(@"PlayingCards.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Cards Drawn");
        }
    }
}
