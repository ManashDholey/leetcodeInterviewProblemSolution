// See https://aka.ms/new-console-template for more information
using leetcode;
using static System.Net.Mime.MediaTypeNames;
var str = "010";
MaximumOddBinaryNumber binaryNumber= new MaximumOddBinaryNumber();
var rb=binaryNumber.RearrangeToMaxOdd(str);
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
TwoNumbers twoNumbers = new TwoNumbers();
var res2=twoNumbers.AddTwoNumbers(list1, list2);
Console.WriteLine($"{res2.val}=>{res2.next.val}=>{res2.next.next.val}");
MergeTwoListsSolution listsSolution= new MergeTwoListsSolution();
var margeNew=listsSolution.MergeTwoLists(list1,list2);
listsSolution.Dispose();
RemoveDuplicatesFromSortedList fromSortedList=new RemoveDuplicatesFromSortedList();
fromSortedList.DeleteDuplicates(list1);
fromSortedList.Dispose();
//Console.WriteLine($"{margeNew.val}=>{margeNew.next.val}=>{margeNew.next.next.val}=>{margeNew.next.next.next.val}=>{margeNew.next.next.next.next.val}=>{margeNew.next.next.next.next.next.val}");


RemoveDuplicatesFromSortedArray removeDuplicates=new RemoveDuplicatesFromSortedArray();
int [] numsRemove = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
Console.WriteLine( removeDuplicates.RemoveDuplicates(numsRemove));
RemoveElement remove = new RemoveElement();
int[] numsRemoveElement = { 3, 2, 2, 3 }; int val = 3;
var res1= remove.RemoveElementFunction(numsRemoveElement, val);
remove.Dispose();
Console.WriteLine(res1);
FirstOccurrenceInAString firstOccurrenceIn=new FirstOccurrenceInAString();
string haystack = "dsadbutsad", needle = "sad";
//string haystack = "leetcode", needle = "leeto";
Console.WriteLine(firstOccurrenceIn.StrStr(haystack, needle));
firstOccurrenceIn.Dispose();
InsertPosition insert=new InsertPosition();

int[] numsInsert = { 1, 3, 5, 6 }; int target1 = 7;
numsInsert.Sum();
List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var r1 = insert.introTutorial(3, numberList);
var d=insert.SearchInsert(numsInsert, target1);
Console.WriteLine(d);
insert.Dispose();
LengthOfLastWord lengthOfLast = new LengthOfLastWord();
Console.WriteLine(lengthOfLast.LengthOfLastWordFun("luffy is still joyboy"));
lengthOfLast.Dispose();

PlusOne plus = new PlusOne();
int[] digits = { 9 };
digits = plus.PlusOneFun(digits);
Console.WriteLine(string.Join(",",digits));
plus.Dispose();
MySqrtSolution mySqrt =new MySqrtSolution();
Console.WriteLine(mySqrt.MySqrt(8));
mySqrt.Dispose();
InsertionSort sort = new InsertionSort();
int n = 5;
List<int> arr = new List<int> { 1, 2, 4, 5, 3 };
sort.insertionSort1(n, arr);
sort.InsertionSort2(n, arr);
sort.Dispose();
List<int> candles = new List<int>() { 3, 2, 1, 3 };
BirthdayCakeCandles birthdayCake=new BirthdayCakeCandles();
Console.WriteLine(birthdayCake.birthdayCakeCandles(candles));
LongestSubstring longestSubstring=new LongestSubstring();
Console.WriteLine(longestSubstring.LengthOfLongestSubstring("abcabcbb"));
longestSubstring.Dispose();
LongestPalindromicSubstring palindromicSubstring=new LongestPalindromicSubstring();
Console.WriteLine(palindromicSubstring.LongestPalindrome("babad"));
Console.WriteLine(palindromicSubstring.LongestPalindrome("cbbd"));
palindromicSubstring.Dispose();
MergeSortedArray mergeSortedArray = new MergeSortedArray();
int[] nums1 = { 1, 2, 3, 0, 0, 0 }; int m1 = 3;
int[] nums2 = { 2, 5, 6 }; int n1 = 3;
mergeSortedArray.Merge(nums1, m1, nums2, n1);
mergeSortedArray.Dispose();
BinaryTreeInorderTraversal binaryTreeInorderTraversal=new BinaryTreeInorderTraversal();
TreeNode root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));
var inorder=binaryTreeInorderTraversal.InorderTraversal(root);
binaryTreeInorderTraversal.Dispose();
Console.WriteLine(string.Join(",",inorder));
AddBinary addBinary=new AddBinary();
Console.WriteLine(addBinary.AddBinaryFunction("11", "1"));
addBinary.Dispose();
SameTree sameTree=new SameTree();
TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(3));
Console.WriteLine(sameTree.IsSameTree(p, q));
sameTree.Dispose();
SymmetricTree symmetricTree=new SymmetricTree();
TreeNode root1 = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3)));
Console.WriteLine(symmetricTree.IsSymmetric(root1));
symmetricTree.Dispose();
MaximumDepthOfBinaryTree maximumDepth=new MaximumDepthOfBinaryTree();
Console.WriteLine(maximumDepth.MaxDepth(root1));
maximumDepth.Dispose();
ConvertSortedArrayToBinarySearchTree convertSorted=new ConvertSortedArrayToBinarySearchTree();
int[] numsConvert = { -10, -3, 0, 5, 9 };
var bst=convertSorted.SortedArrayToBST(numsConvert);
convertSorted.PrintTree(bst);
convertSorted.Dispose();
BalancedBinaryTree balancedBinary=new BalancedBinaryTree();
Console.WriteLine(balancedBinary.IsBalanced(root1));
balancedBinary.Dispose();
MinimumDepthOfBinaryTree minimumDepthOfBinaryTree=new MinimumDepthOfBinaryTree();
// Example 1
TreeNode root2 = new TreeNode(3,
    new TreeNode(9),
    new TreeNode(20, new TreeNode(15), new TreeNode(7))
);
Console.WriteLine(minimumDepthOfBinaryTree.MinDepth(root2)); // Output: 2

// Example 2
TreeNode root3 = new TreeNode(2,
    null,
    new TreeNode(3,
        null,
        new TreeNode(4,
            null,
            new TreeNode(5,
                null,
                new TreeNode(6)
            )
        )
    )
);
Console.WriteLine(minimumDepthOfBinaryTree.MinDepth(root3)); // Output: 5

MaximumDepthOfN_aryTree maximumDepthOfN = new MaximumDepthOfN_aryTree();
Node root4 = new Node(1, new List<Node> {
            new Node(3, new List<Node> {
                new Node(5),
                new Node(6)
            }),
            new Node(2),
            new Node(4)
        });
maximumDepthOfN.MaxDepth(root4);
maximumDepthOfN.Dispose();

TreeNode root5 = new TreeNode(5,
    new TreeNode(4,
        new TreeNode(11,
            new TreeNode(7),
            new TreeNode(2)
        ),
        null
    ),
    new TreeNode(8,
        new TreeNode(13),
        new TreeNode(4, null, new TreeNode(1))
    )
);
PathSum pathSum=new PathSum();
Console.WriteLine(pathSum.HasPathSum(root5, 22));