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
            Complex c = new _444Calculator.Complex();
            Simple s = new Simple();
            bool menuDone = false;
            string simpleChoice = "";
            while (!menuDone)
            {
                Console.WriteLine("This is a simple calculator.  You can change modes if you wish.");
                Console.WriteLine("Choose menu options (1 or 2). Press enter to quit.");
                Console.WriteLine("1. Simple\n2. Complex");
                simpleChoice = Console.ReadLine();
                switch (simpleChoice)
                {
                    case "1":
                        s.Simple_Calculator();
                        break;
                    case "2":
                        c.Complex_Calculator();
                        break;
                    default:
                        menuDone = true;
                        break;
                }
            }
        }
    }
}