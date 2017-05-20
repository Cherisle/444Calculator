using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _444Calculator
{
    class Simple
    {
        public void Simple_Calculator()
        {
            //Creation of variables to be used later
            string equation = "";
            char[] delimiters = { ' ' };
            string[] calculations;

            //User input and prompting
            Console.WriteLine("Enter in a mathematical equation to be computed.");
            Console.WriteLine("For the options, you can enter 'help'.");
            equation = Console.ReadLine();

            //Condition to check if the equation has a + symbol.  If it does, do the addition operation
            if (equation.Contains("+"))
            {
                char[] additionDelim = { '+' };
                calculations = equation.Split(additionDelim);
                int sum = 0;
                for (int i = 0; i < calculations.Length; i++)
                {
                    sum += Int32.Parse(calculations[i]);

                }
                Console.WriteLine("Sum of {0}: {1}", equation, sum);
            }

            //Condition to check if the equation has a - symbol.  If it does, do the subtraction operation
            if (equation.Contains("-") && !equation.Contains("^") && !equation.Contains("!"))
            {
                char[] subtractionDelim = { '-' };
                calculations = equation.Split(subtractionDelim);
                int difference = 0;
                for (int i = 0; i < calculations.Length; i++)
                {
                    difference -= Int32.Parse(calculations[i]);

                }
                Console.WriteLine("Difference of {0}: {1}", equation, difference);
            }

            //Condition to check if the equation the phrase equal.  If it does, do either a is not equal to or equal to
            if (equation.Contains("equal"))
            {
                calculations = equation.Split(delimiters);
                //Checks if there is the phrase not.  if there is, do is not equal to
                if (equation.Contains("not"))
                {
                    if (Int32.Parse(calculations[0]) != Int32.Parse(calculations[5]))
                        Console.WriteLine("{0}?: true", equation);
                    else
                        Console.WriteLine("{0}?: false", equation);
                }
                else if(equation.Contains("^"))
                {
                    char[] delims = {' '};
                    calculations = equation.Split(delims);
                    string pemdasSolveP = ""; // pemdas solve parenthesis
                    string outsideParenthesis = ""; // contents outside the parentheses
                    foreach (var el in calculations)
                    {
                        if(el.Contains("(") || el.Contains(")"))
                        {
                            char[] innerDelim = { ')' };
                            string[] calculations2 = el.Split(innerDelim);
                            outsideParenthesis = calculations2[1];
                            foreach (var item in calculations2)
                            {
                                if(item.Contains("("))
                                {
                                    string trimmed = item.Trim('(');
                                    pemdasSolveP = pemdasSolveP + trimmed;
                                }
                            }                        
                        }
                    }
                    char[] delims2 = {'^'}; // delim by ^ to isolate exponented value
                    string [] calculations3 = pemdasSolveP.Split(delims2);
                    char[] delims3 = { '*', '/', '+', '-' }; // delim by operator signs to perform
                    string[] calculations4 = calculations3[0].Split(delims3);
                    string pemdasSolveE = calculations4[1] +  "^"; //solving for E in pemdas
                    double solved = 0;
                    if(calculations3[1].Contains("/")) // detected fraction, simplify before putting into method
                    {
                        char[] divisionDelim = { '/' };
                        string[] calculations5 = calculations3[1].Split(divisionDelim);
                        double decimalResult = (Double.Parse(calculations5[0]) / Double.Parse(calculations5[1]));
                        pemdasSolveE = pemdasSolveE + decimalResult;
                    }                  
                    pemdasSolveE = simplify(pemdasSolveE); // solved E, case back into pemdasP
                    if (pemdasSolveP.Contains("*")) // detected multiplication, simplify before putting into method
                    {
                        solved = Double.Parse(calculations4[0]) * Double.Parse(pemdasSolveE);
                    }
                    else if (pemdasSolveP.Contains("/")) // detected division, simp before putting into method
                    {
                        solved = Double.Parse(calculations4[0]) / Double.Parse(pemdasSolveE);
                    }
                    else if (pemdasSolveP.Contains("+")) // detected addition, simp before putting into method
                    {
                        solved = Double.Parse(calculations4[0]) + Double.Parse(pemdasSolveE);
                    }
                    else if (pemdasSolveP.Contains("-")) // detected subtraction, simp before putting into method
                    {
                        solved = Double.Parse(calculations4[0]) - Double.Parse(pemdasSolveE);
                    }
                    pemdasSolveP = solved.ToString();
                    string pemdasSolvePE = pemdasSolveP + outsideParenthesis;
                    pemdasSolvePE = simplify(pemdasSolvePE); // final answer
                    if (Double.Parse(pemdasSolvePE) == Double.Parse(calculations[4]))
                        Console.WriteLine("Is {0}?: true", equation);
                    else
                        Console.WriteLine("Is {0}?: false", equation);
                }

                //Else, just do an equal to operation
                else
                {
                    if (Int32.Parse(calculations[0]) == Int32.Parse(calculations[4]))
                        Console.WriteLine("Is {0}?: true", equation);
                    else
                        Console.WriteLine("Is {0}?: false", equation);
                }
            }

            //Condition to check if the equation has a / symbol.  If it does, do the division operation
            if (equation.Contains("/") && !equation.Contains("equal") && !equation.Contains("^"))
            {
                char[] divisionDelim = { '/' };
                calculations = equation.Split(divisionDelim);
                double remainder = (Double.Parse(calculations[0]) % Double.Parse(calculations[1]));
                int quotient = (int)(Double.Parse(calculations[0]) / Double.Parse(calculations[1]));
                Console.WriteLine("Remainder of {0}: {1}", equation, remainder);
                Console.WriteLine("Whole Number quotient of {0}: {1}", equation, quotient);
            }

            //Condition to check if the equation has a * symbol.  If it does, do the multiplication operation
            if (equation.Contains("*"))
            {
                char[] multiDelim = { '*' };
                calculations = equation.Split(multiDelim);
                double product = (Double.Parse(calculations[0]) % Double.Parse(calculations[1]));
                Console.WriteLine("Product of {0}: {1}", equation, product);
            }

            //Condition to check if the equation has the phrase and.  If it does, compare both numbers and return the larger
            if (equation.Contains("and") && !equation.Contains("r"))
            {
                calculations = equation.Split(new[] { " and " }, StringSplitOptions.None);
                double token1 = Double.Parse(simplify(calculations[0]));
                double token2 = Double.Parse(simplify(calculations[1]));
                Console.WriteLine("Greater value between {0} and {1}: {2}",token1,token2,Math.Max(token1, token2));
            }

            //Condition to check if the equation has the phrase random value between.  If it does, generate a random value between the two
            if (equation.Contains("random value between"))
            {
                char[] commaDelim = { ',' };
                calculations = equation.Split(new[] { "random value between " }, StringSplitOptions.None);
                string[] bounds = calculations[1].Split(commaDelim);
                Random rand = new Random();
                Console.WriteLine("Random value between {0} and {1}: {2}", 
                    bounds[0], bounds[1], rand.Next(Int32.Parse(bounds[0]),Int32.Parse(bounds[1])));
            }

            //Condition to check if the equation has a ^ symbol.  If it does, take the power of the number
            if (equation.Contains("^") && !equation.Contains("equal"))
            {
                Console.WriteLine("Value of {0}, {1}",equation,simplify(equation));
            }

            //Condition to check if the equation has a ! symbol.  If it does, take the factorial of the number
            if (equation.Contains("!"))
            {
                char[] factorialDelim = { '!' };
                calculations = equation.Split(factorialDelim);

                BigInteger factorial = 1;
                for(int i= Int32.Parse(calculations[0]); i > 0; i--)
                {
                    factorial = BigInteger.Multiply(factorial,i);
                }

                Console.WriteLine("Factorial value of {0}: {1}", calculations[0], factorial);
            }

            //Gives the user menu options
            if (equation.Contains("help"))
            {
                Console.WriteLine("Here are your options:");
                Console.WriteLine("'x equal to y'\n'x is not equal to y'\n'x!'\n'x^y'\n'random value between x,y'\n'x and y (this is for comparisons)'");
                Console.WriteLine("Also, you can enter any basic math operation such as addition and subtraction\n");
            }
        }

        //Simplifies the ^ symbol to do the power operation
        string simplify(string s)
        {
            if (s.Contains("^"))
            {
                char[] powerDelims = {'^'};
                string[] powerContents = s.Split(powerDelims);

                double baseNum = Double.Parse(powerContents[0]);
                double powerNum = Double.Parse(powerContents[1]);

                s = Math.Pow(baseNum, powerNum).ToString();
            }
            return s;
        }
    }
}
