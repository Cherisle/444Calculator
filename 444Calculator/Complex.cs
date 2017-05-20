using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Michael Tran and Kyle Ho distributed the work evenly throughout the project.  
/// Each person worked together on ALL aspects of the project
/// </summary>

namespace _444Calculator
{
    class Complex
    {
        public void Complex_Calculator()
        {
            bool complexMenuDone = false;
            string menuChoice = "";
            string x, y, u, v, s;
            x = y = u = v = s = "";

            //Menu selection - Kyle Ho & Michael Tran
            Console.WriteLine("This is the 444 Simple Complex Number Calculator.");
            Console.WriteLine("What would you like to do?(Options are case-sensitive)\n");
            while (!complexMenuDone)
            {
                Console.WriteLine("add\ndiv\nmag\nang\n");
                Console.WriteLine("Enter anything else to quit.");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
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
                        complexMenuDone = true;
                        break;
                }
            }
        }

        //Will do the add function of complex numbers - Kyle Ho & Michael Tran
        static void addFunction(string x, string y, string u, string v, string s)
        {
            standardDisplay();
            Console.Write("What is x? ");
            x = Console.ReadLine();
            if (x.Contains("^")) { x = "(" + x + ")"; }

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

        //Divides two equations with complex numbers within them - Kyle Ho & Michael Tran
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

        //Does the magnitude function - Kyle Ho & Michael Tran
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

        //Takes the inverse tangent of an equation - Michael Tran
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

        // Displays to let user know what to input - Michael Tran
        static void standardDisplay()
        {
            Console.WriteLine("First Complex Number: x+yi");
            Console.WriteLine("Second Complex Number: u+vi");
        }

        // Displays to let user know what to input - Kyle Ho
        static void displayForOneEquation()
        {
            Console.WriteLine("First Complex Number: x+yi");
        }

        // Simplifies any number that includes exponent - Michael Tran
        static string simplify(string s)
        {
            if (s.Contains("^"))
            {
                char[] powerDelims = { ' ', '(', ')', '^' };
                string[] powerContents = s.Split(powerDelims);

                double baseNum = Int32.Parse(powerContents[1]);
                double powerNum = Int32.Parse(powerContents[2]);

                s = Math.Pow(baseNum, powerNum).ToString();
            }
            return s;
        }

        //Function that evaluates and delimits based on the symbols within the equation 
        static string evaluate(string s)
        {
            char[] equationDelims = { '[', ']', '(', ')', ',', 'i' };
            string[] equationContents = s.Split(equationDelims);

            //Addition operation - Kyle Ho
            if (equationContents.Contains("+"))
            {
                string realNums = (Int32.Parse(equationContents[1]) + Int32.Parse(equationContents[5])).ToString();
                string imaginaryNums = (Int32.Parse(equationContents[2]) + Int32.Parse(equationContents[6])).ToString();

                s = "" + realNums + " + " + imaginaryNums + "i";
            }

            //Division operation - Kyle Ho
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

            //Magnitude function - Kyle Ho
            if (equationContents.Contains("|"))
            {
                char[] secondParse = { '+', '-', '|', ')', '(' };
                equationContents = s.Split(secondParse);
                equationContents[3] = equationContents[3].Trim('i');
                Console.WriteLine(equationContents[2] + "\n" + equationContents[3]);
                double magVal = Math.Pow((Math.Pow(Int32.Parse(equationContents[2]), 2) +
                                Math.Pow(Int32.Parse(equationContents[3]), 2)), 0.5);
                s = "" + magVal;
            }

            //Angle function - Michael Tran
            if (equationContents.Contains("ang"))
            {
                char[] angParse = { 'a', 'n', 'g', '(', '/', ')', 'i' };
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