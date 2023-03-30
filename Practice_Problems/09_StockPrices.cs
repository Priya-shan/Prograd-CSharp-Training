using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class StockPrices
    {
        public static void Main(string[] args)
        {
            int[] stockPrices = { 7, 1, 5, 2, 6, 4};
            Console.WriteLine(findProfit(stockPrices));

        }
        public static int findProfit(int[] stockPrices)
        {
            int min = stockPrices[0];
            int max = stockPrices[0];
            for (int i = 1; i < stockPrices.Length; i++)
            {
                if (stockPrices[i] < min)
                {
                    min = stockPrices[i];
                    max = stockPrices[i];
                }
                if (stockPrices[i] > max)
                {
                    max = stockPrices[i];
                }
            }
            return max - min;
        }
    }
}
