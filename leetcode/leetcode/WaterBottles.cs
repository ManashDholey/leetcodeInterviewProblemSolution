

namespace leetcode
{
    public  class WaterBottles : DisposableBase
    {
        /// <summary>
        /// return the number of water bottles you can drink
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int count = numBottles;
            while (numBottles >= numExchange)
            {
                var newBottles = numBottles / numExchange;
                count += newBottles;
                numBottles = numBottles % numExchange + newBottles;
            }
            return count;
        }
        /// <summary>
        ///  despose pattern implementation
        /// </summary>
        /// <param name="disposing"></param>
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
