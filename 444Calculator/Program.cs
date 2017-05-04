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
            standardDisplay();
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

            if (equationContents.Contains("/"))
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
                /*string fraction1 = (((Int32.Parse(equationContents[1]) * Int32.Parse(equationContents[5]))
                                   + (Int32.Parse(equationContents[2]) * Int32.Parse(equationContents[6])))
                                   / ((Int32.Parse(equationContents[5])*Int32.Parse(equationContents[5]))
                                  + (Int32.Parse(equationContents[6])*Int32.Parse(equationContents[6])))).ToString();
              
                                    // SHOULD REPRESENT (xu+yv)/(u^2 + v^2)

                string fraction2 = (((Int32.Parse(equationContents[2]) * Int32.Parse(equationContents[5]))
                                   - (Int32.Parse(equationContents[1]) * Int32.Parse(equationContents[6])))
                                   / ((Int32.Parse(equationContents[5]) * Int32.Parse(equationContents[5]))
                                  + (Int32.Parse(equationContents[6]) * Int32.Parse(equationContents[6])))).ToString();
                                    // SHOULD REPRESENT (yu-vx)/(u^2 + v^2)*/
            }

            if (equationContents.Contains("|"))
            {
                char[] secondParse = {'+','-','|',')','('};
                equationContents = s.Split(secondParse);
                string magEquation = Math.Pow(
                    Math.Abs(
                        (Math.Pow(Int32.Parse(equationContents[2]),2)+((-1)*Math.Pow(Int32.Parse(equationContents[3]),2)))
                        )
                    , 0.5).ToString();      
            }

            if (equationContents.Contains("ang")) { }
            return s;
        }
    }
}
