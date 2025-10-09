using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    partial class FindTheMinimumAmountOfTimeToBrewPotions : DisposableBase
    {
        public long MinTime(int[] skill, int[] mana)
        {
            int n = skill.Length;
            int m = mana.Length;

            long[] done = new long[n];

            for (int potion = 0; potion < m; potion++)
            {
                // Forward pass: ensure both wizard and potion are ready
                for (int wizard = 0; wizard < n; wizard++)
                {
                    if (wizard == 0)
                    {
                        done[wizard] = done[wizard] + (long)mana[potion] * skill[wizard];
                    }
                    else
                    {
                        done[wizard] = Math.Max(done[wizard], done[wizard - 1]) + (long)mana[potion] * skill[wizard];
                    }
                }

                // Backward pass: ensure synchronization
                for (int wizard = n - 2; wizard >= 0; wizard--)
                {
                    done[wizard] = Math.Max(done[wizard], done[wizard + 1] - (long)mana[potion] * skill[wizard + 1]);
                }
            }

            return done[n - 1];
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
