namespace leetcode
{
    public class ValidParenthesesSolution : IDisposable
    {
        private bool disposed = false;
        public bool IsValid(string str)
        {

            Stack<char> stack = new();

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    default:
                        if (stack.Count != 0)
                        {
                            char pop = stack.Pop();
                            char c = str[i];
                            if (c != pop)
                                return false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }
            return stack.Count == 0;
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
