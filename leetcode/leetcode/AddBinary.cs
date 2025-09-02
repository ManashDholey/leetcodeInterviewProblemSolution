

namespace leetcode
{
    public class AddBinary : DisposableBase
    {
        public string AddBinaryFunction(string a, string b)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;
            var result = new System.Text.StringBuilder();

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a[i] - '0';
                    i--;
                }

                if (j >= 0)
                {
                    sum += b[j] - '0';
                    j--;
                }

                // Append current bit
                result.Insert(0, (char)((sum % 2) + '0'));
                carry = sum / 2;
            }

            return result.ToString();
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
