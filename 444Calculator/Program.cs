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
            if (y.Contains("^")) { y = simplify(y); }
            Console.Write("What is u? ");
            u = Console.ReadLine();
            Console.Write("What is v? ");
            v = Console.ReadLine();
            if(v.Contains("^")) { v = simplify(v); }
            s = "(" + x + "," + y + "i)+(" + u + "," + v + "i)";
            Console.WriteLine(s);
            if (s.Contains("i"))
            {
                string[] sSubString = s.Split(',');
                // sSubString[0] = (x
                // sSubString[1] = yi)+(u
                // sSubString[2] = vi)
                sSubString[0] = sSubString[0].Trim('(');
                sSubString[2] = sSubString[2].Trim(')');
                // sSubString[0] = x [updated]
                // sSubString[2] = vi [updated]          
                string[] loc1SubString = sSubString[1].Split(new[] { ")+(" }, StringSplitOptions.None);
                // loc1SubString[0] = yi
                // loc1SubString[1] = u
                /*Console.WriteLine(sSubString[0]);
                Console.WriteLine(loc1SubString[0]);
                Console.WriteLine(loc1SubString[1]);
                Console.WriteLine(sSubString[2]);*/
                y = loc1SubString[0] = simplify(loc1SubString[0]);
                v = sSubString[2] = simplify(sSubString[2]);
                s = "(" + x + "," + y + ")+(" + u + "," + v + ")";
                Console.WriteLine(s);
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

        static string simplify(string s)
        {
            if(s.Contains("^"))
            {
                string[] token = s.Split('^');
                int powerCnt = Convert.ToInt32(token[1]);
                if (powerCnt % 4 == 0) { s = token[0]; } // follows i^0,i^4 ==> 1
                if (powerCnt % 4 == 1) { s = token[0]; } // follows i^1, i^5 ==> i
                if (powerCnt % 4 == 2) { s = "-" + token[0]; } // follows i^2, i^6 ==> -1
                if (powerCnt % 4 == 3) { s = "-" + token[0]; } // follows i^3, i^7 ==> -i
            }

            if(s.Contains("0"))
            {
                s = "0";
            }
            return s;
        }
    }
}
