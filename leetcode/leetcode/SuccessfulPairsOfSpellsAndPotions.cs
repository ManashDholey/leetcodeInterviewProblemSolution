using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class SuccessfulPairsOfSpellsAndPotions : DisposableBase
    {

        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions); // Sort the potions for binary search
            int n = spells.Length;
            int m = potions.Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int spell = spells[i];
                int left = 0, right = m - 1, idx = m;

                // Binary search for the first potion where spell * potion >= success
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    long prod = (long)spell * (long)potions[mid];

                    if (prod >= success)
                    {
                        idx = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                result[i] = m - idx;
            }
            return result;
        }

       
        /// <summary>
        /// despose pattern implementation
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
