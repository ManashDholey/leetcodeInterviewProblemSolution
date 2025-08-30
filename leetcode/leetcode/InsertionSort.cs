

namespace leetcode
{
    public  class InsertionSort : IDisposable
    {
        private bool disposed = false;

        public  void printArr(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public  void insertionSort1(int n, List<int> arr)
        {
            int last = arr[arr.Count - 1];
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                if (last < arr[i - 1])
                {
                    arr[i] = arr[i - 1];
                    printArr(arr);
                }
                else
                {
                    arr[i] = last;
                    printArr(arr);
                    break;
                }
            }
        }
        public  void InsertionSort2(int n, List<int> arr)
        {
            for (int index = 1; index < n; index++)
            {
                int insertValue = arr[index];
                for (int subIndex = index - 1; subIndex >= -1; subIndex--)
                {
                    if (subIndex >= 0 && arr[subIndex] > insertValue)
                    {
                        arr[subIndex + 1] = arr[subIndex];
                    }
                    else
                    {
                        arr[subIndex + 1] = insertValue;
                        break;
                    }
                }
                Print(arr);
            }
        }

        private static void Print(List<int> list)
        {
            Console.WriteLine(string.Join(" ", list.Select(x => x.ToString())));
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
