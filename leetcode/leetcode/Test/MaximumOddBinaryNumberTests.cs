using Xunit;

namespace leetcode.Test
{
    public class MaximumOddBinaryNumberTests
    {
        [Fact]
        public void RearrangeToMaxOdd_ReturnsExpected()
        {
            var sut = new MaximumOddBinaryNumber();
            Assert.Equal("100", sut.RearrangeToMaxOdd("010"));
            Assert.Equal("1", sut.RearrangeToMaxOdd("1"));
            Assert.Equal("0", sut.RearrangeToMaxOdd("0"));
            sut.Dispose();
        }
    }
    public class TwoSumSolutionTests
    {
        [Fact]
        public void TwoSum_ReturnsIndices()
        {
            var sut = new TwoSumSolution();
            int[] nums = { 3, 2, 4 };
            int[] result = sut.TwoSum(nums, 6);
            Assert.Equal(2, result.Length);
            sut.Dispose();
        }
    }
    public class PalindromeSolutionTests
    {
        [Fact]
        public void IsPalindrome_ReturnsTrueForPalindrome()
        {
            var sut = new PalindromeSolution();
            Assert.True(sut.IsPalindrome(121));
            Assert.False(sut.IsPalindrome(123));
            sut.Dispose();
        }
    }
    public class RomanToIntegerSolutionTests
    {
        [Fact]
        public void RomanToInt_ReturnsExpected()
        {
            var sut = new RomanToIntegerSolution();
            Assert.Equal(1994, sut.RomanToInt("MCMXCIV"));
            Assert.Equal(3, sut.RomanToInt("III"));
            sut.Dispose();
        }
    }
    public class LongestCommonPrefixSolutionTests
    {
        [Fact]
        public void LongestCommonPrefix_ReturnsExpected()
        {
            var sut = new LongestCommonPrefixSolution();
            string[] strs = { "flower", "flow", "flight" };
            Assert.Equal("fl", sut.LongestCommonPrefix(strs));
            sut.Dispose();
        }
    }
}
