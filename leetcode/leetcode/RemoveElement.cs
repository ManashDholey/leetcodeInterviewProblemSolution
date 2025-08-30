namespace leetcode
{
    public class RemoveElement : IDisposable
    {
        private bool disposed = false;

        public  int RemoveElementFunction(int[] nums, int val)
        {

            var res = nums.Where(x => x != val).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                nums[i] = res[i];
            }
            return res.Length;
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
