using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practice_Problems
{
    internal class _20_RationalDatatype
    {
        public static void Main(string[] args)
        {
            var r1 = new rational(1, 2);
            var r2 = new rational(2, 1);

            Console.WriteLine("The Two Rational Numbers are : " + r1 + " " + r2+"\n");
            Console.WriteLine("Addition : "+(r1+r2));
            Console.WriteLine("Subraction : " + (r1 - r2));
            Console.WriteLine("Multiplication : " + (r1 * r2));
            Console.WriteLine("Division : " + (r1 / r2));
            Console.WriteLine("Unary( "+r1+" ) : " + (-r1));

            Console.WriteLine("isEqual : " + (r1 == r2));
            Console.WriteLine("isNotEqual : " + (r1 != r2));

        }
        struct rational
        {
            public int numerator;
            public int denominator;

            public rational(int numerator, int denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
                try
                {
                    if (denominator == 0)
                    {
                        throw new DivideByZeroException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public override string ToString()
            {
                return $"{numerator}/{denominator}";
            }

            public static rational operator +(rational r1, rational r2)
            {
                int num = (r1.numerator * r2.denominator) + (r2.numerator * r1.denominator);
                int denom = r1.denominator * r2.denominator;
                return new rational(num, denom);
            }

            public static rational operator -(rational r1, rational r2)
            {
                int num = (r1.numerator * r2.denominator) - (r2.numerator * r1.denominator);
                int denom = r1.denominator * r2.denominator;
                return new rational(num, denom);
            }

            public static rational operator *(rational r1, rational r2)
            {
                int num = (r1.numerator * r2.numerator);
                int denom = r1.denominator * r2.denominator;
                return new rational(num, denom);
            }

            public static rational operator /(rational r1, rational r2)
            {
                int num = r1.numerator * r2.denominator;
                int denom = r1.denominator * r2.numerator;
                return new rational(num, denom);
            }
            public static rational operator -(rational r1)
            {
                int num = -r1.numerator;
                int denom = r1.denominator;
                return new rational(num, denom);
            }
            public static bool operator ==(rational r1, rational r2)
            {
                if (r1.numerator == r2.numerator && r1.denominator == r2.denominator)
                {
                    return true;
                }
                return false;
            }
            public static bool operator !=(rational r1, rational r2)
            {
                if (r1.numerator == r2.numerator && r1.denominator == r2.denominator)
                {
                    return false;
                }
                return true;
            }
            public static bool operator <(rational r1, rational r2)
            {
                int num1 = r1.numerator * r2.denominator;
                int num2 = r2.numerator * r2.denominator;
                return r1 < r2;
            }
            public static bool operator >(rational r1, rational r2)
            {
                int num1 = r1.numerator * r2.denominator;
                int num2 = r2.numerator * r2.denominator;
                return r1 > r2;
            }
            public static bool operator <=(rational r1, rational r2)
            {
                int num1 = r1.numerator * r2.denominator;
                int num2 = r2.numerator * r2.denominator;
                return r1 <= r2;
            }
            public static bool operator >=(rational r1, rational r2)
            {
                int num1 = r1.numerator * r2.denominator;
                int num2 = r2.numerator * r2.denominator;
                return r1 >= r2;
            }
        }
    }
}
