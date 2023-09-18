using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class FirstOccurrenceInAString : IDisposable
    {
        private bool disposed = false;
        public int StrStr(string haystack, string needle)
        {
            if (haystack.Contains(needle))
            {
                for (int i = 0; i < haystack.Length; i++)
                {
                    var temp = haystack[i..(needle.Length + i)];
                    if (haystack[i..(needle.Length + i)] == needle)
                    {
                        return i;
                    }
                }
                return 0;
            }
            else
            {
                return -1;
            }
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
