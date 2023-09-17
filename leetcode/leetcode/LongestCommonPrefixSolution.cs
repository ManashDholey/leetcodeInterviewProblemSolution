using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class LongestCommonPrefixSolution : IDisposable
    {
        private bool disposed = false;

        public string LongestCommonPrefix(string[] strs)
        {
            //We need to find shortest element of array to put in for loop.
            //Or we can get OutOfRange error.

            //Length of the shortest element.
            int minLength = strs.Min(x => x.Length);

            //Shotest element itself.
            string? shortest_element = strs.FirstOrDefault(x => x.Length == minLength);

            //Going through the all elements in the list.
            foreach (string item in strs)
            {

                //Once we have an element we going through each character in this element.
                for (int j = 0; j < minLength; j++)
                {

                    //We need to set the index to minLength where characters are not equal to each other.
                    //We will use this minLength to cut the prefix from the shortest element.
                    if (item[j] != shortest_element[j])
                    {
                        minLength = j;
                        break;
                    }
                }
            }
            //Once we found minLength we can cut the shortest element from 0's character to minLength's character.
            return shortest_element.Substring(0, minLength);
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
