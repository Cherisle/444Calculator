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

        static void addFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            if(x.Contains("^")) { x = "(" + x + ")"; }

            Console.Write("What is y? ");
            y = Console.ReadLine();
            if (y.Contains("^")) { y = "(" + y + ")"; }

            Console.Write("What is u? ");
            u = Console.ReadLine();
            if (u.Contains("^")) { u = "(" + u + ")"; }

            Console.Write("What is v? ");
            v = Console.ReadLine();
            if (v.Contains("^")) { v = "(" + v + ")"; }

            // start to simplify here

            x = simplify(x); y = simplify(y); u = simplify(u); v = simplify(v);
            s = "[" + x + "," + y + "i]+[" + u + "," + v + "i]";
            Console.WriteLine(s);

            Console.WriteLine("Evaluated Result: {0}", evaluate(s));
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

            // start to simplify here

            x = simplify(x); y = simplify(y); u = simplify(u); v = simplify(v);
            s = "[" + x + "," + y + "i]/[" + u + "," + v + "i]";
            Console.WriteLine(s);

            Console.WriteLine("Evaluated Result: {0}", evaluate(s));
        }

        static void magFunction(string x, string y, string u, string v, string s)
        {
            displayForOneEquation();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();

            x = simplify(x); y = simplify(y);
            s = "(|" + x + "+" + y + "i|)";
            Console.WriteLine(s);

            Console.WriteLine("Evaluated Result: {0}", evaluate(s));
        }

        static void angFunction(string x, string y, string u, string v, string s)
        {
            displayForOneEquation();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            Console.Write("What is y? ");
            y = Console.ReadLine();
            x = simplify(x); y = simplify(y);
            s = "ang(" + y + "/" + x + "i)";
            Console.WriteLine(s);
            Console.WriteLine("Evaluated Result in radians: {0}", evaluate(s));

        }

        static void standardDisplay()
        {
            Console.WriteLine("First Complex Number: x+yi");
            Console.WriteLine("Second Complex Number: u+vi");
        }

        static void displayForOneEquation()
        {
            Console.WriteLine("First Complex Number: x+yi");
        }

        static string simplify(string s)
        {
            if(s.Contains("^"))
            {
                char[] powerDelims = { ' ', '(', ')', '^'};
                string[] powerContents = s.Split(powerDelims);

                double baseNum = Int32.Parse(powerContents[1]);
                double powerNum = Int32.Parse(powerContents[2]);

                s = Math.Pow(baseNum, powerNum).ToString();
            }
            return s;
        }

        static string evaluate(string s)
        {
            char[] equationDelims = { '[', ']', '(', ')', ',', 'i' };
            string[] equationContents = s.Split(equationDelims);
            if (equationContents.Contains("+"))
            {
                string realNums = (Int32.Parse(equationContents[1]) + Int32.Parse(equationContents[5])).ToString();
                string imaginaryNums = (Int32.Parse(equationContents[2]) + Int32.Parse(equationContents[6])).ToString();

                s = "" + realNums + " + " + imaginaryNums + "i";
            }

            if (equationContents.Contains("/") && !equationContents.Contains("ang"))
            {
                double numerator1, numerator2, denominator = 0;
                string fraction1 = "";
                string fraction2 = "";
                numerator1 = ((Int32.Parse(equationContents[1]) * Int32.Parse(equationContents[5]))
                                   + (Int32.Parse(equationContents[2]) * Int32.Parse(equationContents[6])));            
                numerator2 = ((Int32.Parse(equationContents[2]) * Int32.Parse(equationContents[5]))
                                   - (Int32.Parse(equationContents[1]) * Int32.Parse(equationContents[6])));
                denominator = ((Int32.Parse(equationContents[5]) * Int32.Parse(equationContents[5]))
                                  + (Int32.Parse(equationContents[6]) * Int32.Parse(equationContents[6])));
                if (denominator == 0)
                {
                    Console.WriteLine("Calculation cannot be done because you are dividing by 0");
                }
                else
                {
                    fraction1 = (numerator1 / denominator).ToString();
                    fraction2 = (numerator2 / denominator).ToString();
                    if (fraction2.Contains("-")) { s = "" + fraction1 + fraction2 + "i"; }
                    else { s = "" + fraction1 + " + " + fraction2 + "i"; }
                }
            
            }

            if (equationContents.Contains("|"))
            {
                char[] secondParse = {'+','-','|',')','('};                
                equationContents = s.Split(secondParse);
                equationContents[3] = equationContents[3].Trim('i');
                Console.WriteLine(equationContents[2] + "\n" + equationContents[3]);
                double magVal = Math.Pow((Math.Pow(Int32.Parse(equationContents[2]),2) +
                                Math.Pow(Int32.Parse(equationContents[3]),2)),0.5);
                s = "" + magVal;
            }

            if (equationContents.Contains("ang"))
            {
                char[] angParse = { 'a','n','g','(','/',')','i' };
                equationContents = s.Split(angParse);

                double radians = Math.Atan2(Int32.Parse(equationContents[4]), Int32.Parse(equationContents[5]));
                double angle = radians * (180 / Math.PI);
                Console.WriteLine("Evaluated Result in degrees: {0}", angle);
                s = "" + radians;
            }
            return s;
        }
    }
}