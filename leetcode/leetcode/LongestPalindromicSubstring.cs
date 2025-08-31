

namespace leetcode
{
    public class LongestPalindromicSubstring : IDisposable
    {
        private bool disposedValue;

        public  string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 1)
                return "";
   
            int start = 0, end = 0;
            
            for (int i = 0; i < s.Length; i++)
            {
                // Odd length palindrome
                int len1 = ExpandFromCenter(s, i, i);
                // Even length palindrome
                int len2 = ExpandFromCenter(s, i, i + 1);

                int len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private  int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        public string MediumLongestPalindrome(string str)
        {
            if (str.Length <= 1)
                return str;

            string LPS = "";

            for (int i = 1; i < str.Length; i++)
            {
                // Consider odd length palindrome
                int low = i;
                int high = i;

                while (low >= 0 && high < str.Length && str[low] == str[high])
                {
                    low--;
                    high++;

                    if (low == -1 || high == str.Length)
                        break;
                }

                string palindrome = str.Substring(low + 1, high - (low + 1));
                if (palindrome.Length > LPS.Length)
                {
                    LPS = palindrome;
                }

                // Consider even length palindrome
                low = i - 1;
                high = i;

                while (low >= 0 && high < str.Length && str[low] == str[high])
                {
                    low--;
                    high++;

                    if (low == -1 || high == str.Length)
                        break;
                }

                palindrome = str.Substring(low + 1, high - (low + 1));
                if (palindrome.Length > LPS.Length)
                {
                    LPS = palindrome;
                }
            }

            return LPS;
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LongestPalindromicSubstring()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
