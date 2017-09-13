using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    delegate int Comparer<T>(T x, T y);

    class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return $@"{Numerator}/{Denominator}";
        }
    }

    class Program
    {
        static int CompareFraction(Fraction x, Fraction y)
        {
            int retValue = 0;

            double fract1 = (double)x.Numerator / x.Denominator;
            double fract2 = (double)y.Numerator / y.Denominator;

            if (fract1 < fract2)
            {
                retValue = -1;
            }
            else if (fract1 > fract2)
            {
                retValue = 1;
            }
            // else means we are the exactly equal, so retValue remains at 0;

            return retValue;
        }

        static int CompareString(string x, string y)
        {
            return x.CompareTo(y);
        }

        static void Sort<T>(T[] elements, Comparer<T> compare)
        {
            // Sort array in order using the comparer behaviour we've injected into this function.
            for (int i = 0; i < elements.Length - 1; i++)
            {
                int minIndex = i; // Assume "smallest" element is at position i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (compare(elements[j], elements[minIndex]) < 0)
                    {
                        minIndex = j; // new "smallest" element identified
                    }
                }
                // If we've found a new smallest value, move it to its rightful in order place in the array.
                if (minIndex != i)
                {
                    T x = elements[i];
                    elements[i] = elements[minIndex];
                    elements[minIndex] = x;
                }
            }
        }

        static void FuncSort<T>(T[] elements, Func<T, T, int> compare)
        {
            // Sort array in order using the comparer behaviour we've injected into this function.
            for (int i = 0; i < elements.Length - 1; i++)
            {
                int minIndex = i; // Assume "smallest" element is at position i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (compare(elements[j], elements[minIndex]) < 0)
                    {
                        minIndex = j; // new "smallest" element identified
                    }
                }
                // If we've found a new smallest value, move it to its rightful in order place in the array.
                if (minIndex != i)
                {
                    T x = elements[i];
                    elements[i] = elements[minIndex];
                    elements[minIndex] = x;
                }
            }
        }

        public static void Main(string[] args)
        {
            Fraction[] fractions = { new Fraction(1000, 10), new Fraction(5, 9), new Fraction(2, 5), new Fraction(12, 65), new Fraction(16, 5) };
            string[] words = { "car", "xylophone", "cod", "history", "stagnant", "alphabet" };
            string[] words2 = { "tiger", "sociopath", "angle", "calculus", "moron", "dork" };

            Sort<Fraction>(fractions, new Comparer<Fraction>(CompareFraction));
            foreach (Fraction f in fractions)
            {
                Console.Write(f + " ");
            }

            Console.WriteLine();

            Sort(words, new Comparer<string>(CompareString));
            foreach (string s in words)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine();

            FuncSort<string>(words2, new Func<string, string, int>(CompareString));
            foreach (string s in words2)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine();
        }
    }
}
