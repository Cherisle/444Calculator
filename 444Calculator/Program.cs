﻿using System;
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
            string x, y, u, v, s;
            x = y = u = v = s = "";
            Console.WriteLine("This is the 444 Simple Complex Number Calculator.");
            Console.WriteLine("What would you like to do?(Options are case-sensitive)\n");
            while(!menuDone)
            {
                Console.WriteLine("add\ndiv\nmag\nang\n");
                Console.WriteLine("Enter anything else to quit.");
                menuChoice = Console.ReadLine();
                Console.WriteLine(menuChoice);
                switch(menuChoice)
                {
                    case "add":
                        addFunction(x, y, u, v, s);
                        break;
                    case "div":
                        divFunction(x, y, u, v, s);
                        break;
                    case "mag":
                        magFunction(x, y, u, v, s);
                        break;
                    case "ang":
                        angFunction(x, y, u, v, s);
                        break;
                    default:
                        menuDone = true;
                        break;              
                }
            }
            Console.ReadKey();
        }

        static void addFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();
            Console.Write("What is u? ");
            u = Console.ReadLine();
            Console.Write("What is v? ");
            v = Console.ReadLine();
            s = "(" + x + "," + y + "i)+(" + u + "," + v + "i)";
            //Console.WriteLine(s);
            if (s.Contains("i"))
            {
                string[] sSubString = s.Split(',');
                // [0] = (x
                // [1] = yi)+(u
                // [2] = vi)
                sSubString[0] = sSubString[0].Trim('(');
                sSubString[2] = sSubString[2].Trim(')');
                // [0] = x
                // [2] = vi             
                string[] loc1SubString = sSubString[1].Split(new[] { ")+(" }, StringSplitOptions.None);
                // [0] = yi
                // [1] = u
                Console.WriteLine(sSubString[0]);
                Console.WriteLine(loc1SubString[0]);
                Console.WriteLine(loc1SubString[1]);
                Console.WriteLine(sSubString[2]);
            }            
        }

        static void divFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();
            Console.Write("What is u? ");
            u = Console.ReadLine();
            Console.Write("What is v? ");
            v = Console.ReadLine();
        }

        static void magFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();
            Console.Write("What is u? ");
            u = Console.ReadLine();
            Console.Write("What is v? ");
            v = Console.ReadLine();
        }

        static void angFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();
            Console.Write("What is u? ");
            u = Console.ReadLine();
            Console.Write("What is v? ");
            v = Console.ReadLine();
        }

        static void standardDisplay()
        {
            Console.WriteLine("First Complex Number: x+yi");
            Console.WriteLine("Second Complex Number: u+vi");
        }
    }
}
