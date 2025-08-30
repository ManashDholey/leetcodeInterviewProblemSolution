

namespace leetcode
{
    public class Hourglass : IDisposable
    {
        private bool disposed = false;

        public  int hourglassSum(List<List<int>> arr)
        {
            var maxSum = int.MinValue;
            for (var i = 0; i < arr.Count - 2; i++)
            {
                for (var j = 0; j < arr.Count - 2; j++)
                {
                    var currentSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]              // 1 row
                                      + arr[i + 1][j + 1]                                      // 2 row
                                      + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]; // 3 row

                    maxSum = maxSum < currentSum
                        ? currentSum
                        : maxSum;
                }
            }

            return maxSum;
        }
        public static List<int> matchingStrings(List<string> stringList, List<string> queries)
        {
            Dictionary<string, int> stringCountMap = new Dictionary<string, int>();

            // Count the occurrences of each string in the strings array
            foreach (string str in stringList)
            {
                if (stringCountMap.ContainsKey(str))
                {
                    stringCountMap[str]++;
                }
                else
                {
                    stringCountMap[str] = 1;
                }
            }

            List<int> results = new List<int>();

            // For each query, look up its count in the map
            for (int i = 0; i < queries.Count; i++)
            {
                if (stringCountMap.ContainsKey(queries[i]))
                {
                    results.Add(stringCountMap[queries[i]]);
                }
                else
                {
                    results.Add(0);
                }
            }

            return results;
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                //if (disposing)
                //{
                //    // Dispose managed resources.

                //}
                // Note disposing has been done.
                disposed = true;
            }
        }
    }
}
   

