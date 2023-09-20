// See https://aka.ms/new-console-template for more information
using leetcode;
using static System.Net.Mime.MediaTypeNames;

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
ValidParenthesesSolution valid=new ValidParenthesesSolution();
var r = valid.IsValid("(]");
Console.WriteLine(r);
ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));
MergeTwoListsSolution listsSolution= new MergeTwoListsSolution();
var margeNew=listsSolution.MergeTwoLists(list1,list2);
Console.WriteLine($"{margeNew.val}=>{margeNew.next.val}=>{margeNew.next.next.val}=>{margeNew.next.next.next.val}=>{margeNew.next.next.next.next.val}=>{margeNew.next.next.next.next.next.val}");
LengthOfLastWord lengthOfLast = new LengthOfLastWord();
Console.WriteLine(lengthOfLast.LengthOfLastWordFun("luffy is still joyboy"));