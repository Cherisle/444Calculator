using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _444Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuDone = false;
            string menuChoice = "";
            Console.Write("This is the 444 Simple Complex Number Calculator.");
            Console.WriteLine("What would you like to do?");
            while(!menuDone)
            {
                Console.WriteLine("1. Add\n2. Div\n3. Mag\n4. Ang");
                Console.WriteLine("Enter anything else to quit.");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                menuChoice = key.KeyChar.ToString();
                switch(menuChoice)
                {
                    case "1":
                        addFunction();
                        break;
                    case "2":
                        divFunction();
                        break;
                    case "3":
                        magFunction();
                        break;
                    case "4":
                        angFunction();
                        break;
                    default:
                        menuDone = true;
                        break;              
                }
            }
        }

        static void addFunction()
        {

        }

        static void divFunction()
        {

        }

        static void magFunction()
        {

        }

        static void angFunction()
        {

        }
    }
}
