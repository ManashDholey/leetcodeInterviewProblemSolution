using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class RemoveDuplicatesFromSortedList: IDisposable
    {
        private bool disposed = false;

        public ListNode DeleteDuplicates(ListNode head)
        {
            while (Changed(head)) ;
            return head;
        }

        private bool Changed(ListNode head)
        {
            ListNode current = head;
            bool changed = false;
            while (current != null)
            {
                ListNode next = current.next;
                if (next != null && next.val == current.val)
                {
                    current.next = next.next;
                    changed = true;
                }
                current = current.next;
            }
            return changed;
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
