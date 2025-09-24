

namespace leetcode
{
    public  class MaximumOddBinaryNumber : DisposableBase
    {
     public string RearrangeToMaxOdd(string s)
        {
            char[] arr = s.ToCharArray();
            int rightmostOneIndex = -1;

            // Find the rightmost '1'.
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == '1')
                {
                    rightmostOneIndex = i;
                    break;
                }
            }

            // Find the leftmost '1' starting from the left end of the string.
            int leftmostOneIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '1')
                {
                    leftmostOneIndex = i;
                    break;
                }
            }

            // If there's only one '1', return the original string.
            if (leftmostOneIndex == rightmostOneIndex)
            {
                arr[arr.Length-rightmostOneIndex] = '1';
                arr[leftmostOneIndex] = '0';
                return string.Join("", arr);
            }

            // Swap the rightmost '1' with the leftmost '1'.
            arr[rightmostOneIndex] = '1';
            arr[leftmostOneIndex] = '0';

            return string.Join("", arr); ;
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
