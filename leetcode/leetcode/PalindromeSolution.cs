

namespace leetcode
{
    public class PalindromeSolution : IDisposable
    {
        private bool disposed = false;
        public PalindromeSolution() { }
        public bool IsPalindrome(int x)
        {
            string PalindromeFirst = x.ToString();             //turn to string (easy to reverse)
            char[] charArr = PalindromeFirst.ToCharArray();   //the original target
            char[] reverseArr = PalindromeFirst.ToCharArray();

            Array.Reverse(reverseArr);

            return charArr.SequenceEqual(reverseArr); //compare two array
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
