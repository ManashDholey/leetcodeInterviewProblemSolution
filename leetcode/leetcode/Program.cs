// See https://aka.ms/new-console-template for more information
using leetcode;

Console.WriteLine("Hello, World!");
//int[] nums = { 2, 7, 11, 15 };
int target = 9;
int[] nums = { 3, 2, 4}; target = 6;
TwoSumSolution twoSumSolution = new TwoSumSolution();
int[] result = twoSumSolution.TwoSum(nums, target);
twoSumSolution.Dispose();
if (result.Length == 2)
{
    Console.WriteLine("Indices of elements that add up to the target:");
    Console.WriteLine("Index 1: " + result[0]);
    Console.WriteLine("Index 2: " + result[1]);
}
else
{
    Console.WriteLine("No solution found.");
}
PalindromeSolution palindrome =new PalindromeSolution();
Console.WriteLine(palindrome.IsPalindrome(121));
palindrome.Dispose();
RomanToIntegerSolution romanToInteger= new RomanToIntegerSolution();
var res=romanToInteger.RomanToInt("MCMXCIV");
romanToInteger.Dispose();
Console.WriteLine(res);
LongestCommonPrefixSolution longestCommonPrefix = new LongestCommonPrefixSolution();
//string [] strs = {"dog", "racecar", "car"};
string[] strs = { "flower", "flow", "flight" ,"flkf"};
var rs=longestCommonPrefix.LongestCommonPrefix(strs);
longestCommonPrefix.Dispose();
Console.WriteLine(rs);