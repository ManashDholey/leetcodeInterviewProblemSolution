

namespace leetcode
{
    public class PascalSTriangle : DisposableBase
    {
        //i-th element =(i)th element of previous row + (i-1)th element of previous row
        public List<List<int>> Generate(int numRows)
        {
            List<List<int>> result = new List<List<int>>();
            if (numRows == 0)
                return result;
            List<int> fastRow = new List<int>();
            fastRow.Add(1);
            result.Add(fastRow);

            if(numRows == 1)
                return result;
            for (int i = 1; i < numRows; i++)
            {
                List<int> prevRow = result[i-1];
                List<int> row = new List<int>();
                row.Add(1);
                for(int j = 0; j < i-1; j++)
                {
                 row.Add(prevRow[j]+ prevRow[j+1]);
                }
                row.Add(1);
                result.Add(row);
            }
            return result;
        }
       public void PrintPascalsTriangle(List<List<int>> triangle)
        {
            int numRows = triangle.Count;

            for (int i = 0; i < numRows; i++)
            {
                // Print leading spaces for centering
                Console.Write(new string(' ', (numRows - i - 1) * 2));

                // Print row elements
                foreach (var val in triangle[i])
                {
                    Console.Write(val + "   "); // spacing between numbers
                }

                Console.WriteLine();
            }
        }
        public IList<int> GetRow(int rowIndex)
        {
            List<int> res = new List<int> { 1 };

            for (int i = 0; i < rowIndex; i++)
            {
                List<int> next = new List<int> { 1 };

                for (int j = 0; j < res.Count - 1; j++)
                {
                    next.Add(res[j] + res[j + 1]);
                }

                next.Add(1);
                res = next;
            }

            return res;
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
