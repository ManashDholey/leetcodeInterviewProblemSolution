using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class MergeTwoListsSolution : IDisposable
    {
        private bool disposed = false;
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            return MergeTwoItems(list1, list2);
        }

        private ListNode MergeTwoItems(ListNode A, ListNode B)
        {
            if (A == null) return B;
            if (B == null) return A;

            if (A.val < B.val)
            {
                A.next = MergeTwoItems(A.next, B);
                return A;
            }
            else
            {
                B.next = MergeTwoItems(A, B.next);
                return B;
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
