using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class AvoidFloodInTheCity : DisposableBase
    {

        public int[] AvoidFlood(int[] rains)
        {
            // Initialize the answer array.
            // In C#, we use '1' for days where it doesn't rain
            // or for '0' days that are not used to dry a lake.
            // The problem description implies '1' is a safe default for '0' days.
            int[] ans = new int[rains.Length];
            Array.Fill(ans, 1);

            // A SortedSet<int> is the C# equivalent of a C++ std::set<int>.
            // It stores elements in increasing order and provides efficient
            // operations like finding the next greater element (using GetViewBetween/BinarySearch conceptually,
            // but we'll use a direct iteration/search approach or LINQ for a closer 'lower_bound' equivalent
            // if a direct method isn't available, but a simple loop or a specialized data structure
            // is often clearer). For this specific use case, a direct `SortedSet` combined
            // with `FirstOrDefault` or a manual search can mimic `lower_bound`.
            // A direct equivalent to `std::set::lower_bound` is not built-in, so we'll adapt.
            SortedSet<int> dryDays = new SortedSet<int>(); // To store indices of '0' days (dry days)

            // A Dictionary<int, int> is the C# equivalent of an C++ std::unordered_map<int, int>.
            // lake number --> last index it occurred
            Dictionary<int, int> lastRainDay = new Dictionary<int, int>();

            for (int i = 0; i < rains.Length; i++)
            {
                if (rains[i] == 0)
                {
                    // No rain, store '0' day's index in the set of available dry days
                    dryDays.Add(i);
                }
                else
                {
                    // Rain day
                    ans[i] = -1; // Update ans: lake is filled on this day

                    int currentLake = rains[i];

                    if (lastRainDay.ContainsKey(currentLake))
                    {
                        // This lake has rained before (duplicate)

                        // Find the first dry day (index from dryDays) that occurs
                        // AFTER the last time this lake was filled (lastRainDay[currentLake]).
                        int lastIndex = lastRainDay[currentLake];

                        // C# doesn't have a direct 'lower_bound' like C++.
                        // We can use LINQ or iterate over the SortedSet to find the first
                        // element greater than or equal to 'lastIndex'.

                        // Using LINQ's FirstOrDefault for a concise solution:
                        int? dryDayIndex = dryDays.FirstOrDefault(index => index >= lastIndex);

                        if (dryDayIndex == 0 && !dryDays.Contains(0) && lastIndex != 0)
                        {
                            // FirstOrDefault returns the default value (0 for int) if no element is found.
                            // We need to check if 0 was actually a valid index found, or the default.
                            // A safer way is to check if it's found at all:
                            dryDayIndex = dryDays.FirstOrDefault(index => index >= lastIndex);
                            if (dryDayIndex == 0 && !dryDays.Contains(0))
                            {
                                // If dryDays contains '0', this check fails.
                                // A more robust check:
                                if (dryDays.All(index => index < lastIndex))
                                {
                                    // No '0' day available after the last rain for this lake --> flood
                                    return Array.Empty<int>();
                                }
                            }
                        }

                        // A manual loop or a custom method is often clearer and sometimes more performant than LINQ
                        // for this specific task in performance-critical C# code.

                        int indexToDry = -1;
                        foreach (int dryIndex in dryDays)
                        {
                            if (dryIndex >= lastIndex)
                            {
                                indexToDry = dryIndex;
                                break;
                            }
                        }

                        if (indexToDry == -1)
                        {
                            // No '0' day available after the last rain for this lake --> flood
                            return Array.Empty<int>();
                        }

                        // '0' day's index found --> update ans to dry the lake on that day
                        ans[indexToDry] = currentLake;

                        // Remove used '0' index from the set
                        dryDays.Remove(indexToDry);
                    }

                    // Update the last time this lake rained
                    lastRainDay[currentLake] = i;
                }
            }

            // Days with '0' that were not used to dry a specific lake remain '1' as initialized.
            return ans;
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
