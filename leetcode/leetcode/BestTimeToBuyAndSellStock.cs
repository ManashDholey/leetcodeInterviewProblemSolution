
namespace leetcode
{
    public class BestTimeToBuyAndSellStock : DisposableBase
    {
        /// <summary>
        /// return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int MaxProfit = 0;
            int buyPrice = int.MaxValue;
            int currentProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < buyPrice)
                {
                    buyPrice = prices[i];
                }
                currentProfit = prices[i] - buyPrice;
                if (currentProfit > MaxProfit)
                {
                    MaxProfit = currentProfit;
                }
            }
            return MaxProfit;
        }
        /// <summary>
        /// return the maximum profit you can achieve. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfitTwo(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int n = prices.Length;
            int[,] dp = new int[n, 2];

            // Base cases
            dp[0, 0] = 0;            // Not holding any stock on day 0
            dp[0, 1] = -prices[0];   // Holding stock after buying on day 0

            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]); // Sell today or do nothing
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]); // Buy today or do nothing
            }

            // Final answer: profit on last day when not holding stock
            return dp[n - 1, 0];
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
            }
            // No unmanaged resources, so nothing extra here
            // Call base to set _disposed flag
            base.Dispose(disposing);
        }
    }
}
