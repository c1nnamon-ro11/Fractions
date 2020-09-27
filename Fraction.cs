using System;
using System.IO;

namespace Fractals
{
    class Fraction
    {
        //Fields
        int numerator;
        int denominator;
        int integer;
        string sign;

        //Constructor
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
            integer = 0;
        }

        public Fraction(string number)
        {
            //Exception (wrong fractal data)
                numerator = int.Parse(number.Split('/')[0]);
                denominator = int.Parse(number.Split('/')[1]);
                //Simplification fraction sign
                if (denominator < 0) {
                    denominator = -denominator;
                    numerator = -numerator;
                }
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }

        }

        static int CommonDedominator(int denominatorOfFirstFraction, int denominatorOfSecondFraction)
        {
            int CommonDedominator;
            int newDenominator;
            int multiplier = 2; //counter than increases if newDenominator isn`t result

            //if denominators of fractions are multiples
            if (denominatorOfFirstFraction > denominatorOfSecondFraction)
            {
                CommonDedominator = denominatorOfFirstFraction;
                if (CommonDedominator % denominatorOfSecondFraction == 0) return CommonDedominator;
            }
            else
            {
                CommonDedominator = denominatorOfSecondFraction;
                if (CommonDedominator % denominatorOfFirstFraction == 0) return CommonDedominator;
            }

            //if denominators of fractions are not multiples
            while (true)
            {
                newDenominator = CommonDedominator * multiplier;
                if (newDenominator % denominatorOfFirstFraction == 0 && newDenominator % denominatorOfSecondFraction == 0)
                {
                    return newDenominator;
                }
                multiplier++;
            }
        }
        //Four operations
        public Fraction PlusFractals(Fraction second)
        {
            Fraction answer = new Fraction();
            answer.denominator = CommonDedominator(denominator, second.denominator);
            answer.numerator = numerator * (answer.denominator / denominator) + second.numerator * (answer.denominator / second.denominator);
            return answer;
        }

        public Fraction MinusFractals(Fraction second)
        {
            Fraction answer = new Fraction();
            answer.denominator = CommonDedominator(denominator, second.denominator);
            answer.numerator = numerator * (answer.denominator / denominator) - second.numerator * (answer.denominator / second.denominator);
            return answer;
        }
        public Fraction MultyFractals(Fraction second)
        {
            Fraction answer = new Fraction();
            answer.denominator = denominator * second.denominator;
            answer.numerator = numerator * second.numerator;
            return answer;
        }
        public Fraction DivideFractals(Fraction second)
        {
            Fraction answer = new Fraction();
            answer.denominator = denominator * second.numerator;
            answer.numerator = numerator * second.denominator;
            return answer;
        }

        //Largest Common Divisor for fraction simplification 
        public int LargestCommonDivisor(int numerator, int denominator)
        {
            while (numerator != denominator)
            {
                if (numerator == 0)
                    break;
                if (numerator > denominator)
                    numerator = numerator - denominator;
                else denominator = denominator - numerator;
            }
            return numerator;
        }


        public void Simplification()
        {
            int div = LargestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            numerator/= div;
            denominator/= div;
            if (numerator < 0 && denominator < 0) { numerator = -numerator; denominator = -denominator; }
        }

        //If  you need mixed number
        public void IntegerPart()
        {
            if (numerator < 0) sign = "-";
            else sign = "+";
            numerator = Math.Abs(numerator);
            while (numerator >= denominator)
            {
                integer++;
                numerator -= denominator;
            }
        }

        public override string ToString()
        {
            Simplification();
            IntegerPart();
            if (integer == 0 && numerator == 0) return "0";
            if (integer == 0) return sign + numerator + "/" + denominator;
            if (numerator == 0) return sign + integer;
            return sign + integer + " " + numerator + "/" + denominator;
        }
    }
}
