

namespace leetcode
{
    public class ComputeDecimalRepresentation : DisposableBase
    {
        /// <summary>
        /// returns an array of the decimal representation of the integer n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] DecimalRepresentation(int n)
        {
            List<int> result = new List<int>();
            int place = 1;

            while (n > 0)
            {
                int digit = n % 10;
                if (digit != 0)
                {
                    result.Add(digit * place);
                }
                n /= 10;
                place *= 10;
            }

            // Sort in descending order as required
            result.Sort((a, b) => b.CompareTo(a));
            return result.ToArray();
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
