using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class RomanToIntegerSolution : IDisposable
    {
        private bool disposed = false;

        private readonly Dictionary<char, int> dict = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        public int RomanToInt(string s)
        {

            char[] ch = s.ToCharArray();

            int result = 0;
            int intVal, nextIntVal;

            for (int i = 0; i < ch.Length; i++)
            {
                intVal = dict[ch[i]];

                if (i != ch.Length - 1)
                {
                    nextIntVal = dict[ch[i + 1]];

                    if (nextIntVal > intVal)
                    {
                        intVal = nextIntVal - intVal;
                        i = i + 1;
                    }
                }
                result = result + intVal;
            }
            return result;
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
