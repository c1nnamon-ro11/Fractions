using System;

namespace Fractals
{  
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter data: ");
                string[] str = Console.ReadLine().Split(' ');
                //str[0] - first fraction
                //str[1] - operation
                //str[2] - second fraction
                //Wrong data format
                if (str.Length != 3) throw new Exception();

                Fraction firstFraction = new Fraction(str[0]);
                Fraction secondFraction = new Fraction(str[2]);
                Fraction answerFraction;

                switch (str[1]) //Operations            
                {
                    case "+":
                        answerFraction = firstFraction.PlusFractals(secondFraction);
                        Console.WriteLine(answerFraction.ToString());
                        break;
                    case "-":
                        answerFraction = firstFraction.MinusFractals(secondFraction);
                        Console.WriteLine(answerFraction.ToString());
                        break;
                    case "*":
                        answerFraction = firstFraction.MultyFractals(secondFraction);
                        Console.WriteLine(answerFraction.ToString());
                        break;
                    case "/":
                        answerFraction = firstFraction.DivideFractals(secondFraction);
                        Console.WriteLine(answerFraction.ToString());
                        break;
                    default:
                        Console.WriteLine("Incorrect operation!");
                        break;
                }
                Console.WriteLine("Want repeat?: y/n");
                if(Console.ReadLine() !="y")
                break;
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
