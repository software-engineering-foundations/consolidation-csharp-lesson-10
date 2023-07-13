using System.Collections;
using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace consolidation_csharp_lesson_10;

public class TestChallenges
{
    public static IEnumerable UniqueSumTestCases()
    {
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 3 }, 6).Returns(2);
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 10).Returns(0);
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6 }, 7).Returns(2);
    }

    [TestCaseSource(nameof(UniqueSumTestCases))]
    public int TestUniqueSum(int[] nums, int targetSum)
    {
        return Challenges.UniqueSum(nums, targetSum);
    }

    public static IEnumerable ClosestSumTestCases()
    {
        yield return new TestCaseData(new[] { -1, 2, 1, -4 }, 1).Returns(2);
        yield return new TestCaseData(new[] { 0, 0, 0 }, 1).Returns(0);
        yield return new TestCaseData(new[] { 1, 1, 1, 0 }, -100).Returns(2);
    }

    [TestCaseSource(nameof(ClosestSumTestCases))]
    public int TestClosestSum(int[] nums, int target)
    {
        return Challenges.ClosestSum(nums, target);
    }

    public static IEnumerable LongestSubstringWithKDistinctTestCases()
    {
        yield return new TestCaseData("eceba", 2).Returns(3);
        yield return new TestCaseData("abcde", 1).Returns(1);
        yield return new TestCaseData("abcde", 5).Returns(5);
        yield return new TestCaseData("babac", 3).Returns(4);
        yield return new TestCaseData("a", 0).Returns(0);
    }

    [TestCaseSource(nameof(LongestSubstringWithKDistinctTestCases))]
    public int TestLongestSubstringWithKDistinct(string input, int distinctCharacters)
    {
        return Challenges.LongestSubstringWithKDistinct(input, distinctCharacters);
    }

    public static IEnumerable MaxProfitTestCases()
    {
        yield return new TestCaseData(new[] { 1, 2, 1, -4 }).Returns(1);
        yield return new TestCaseData(new[] { 0, 0, 0 }).Returns(0);
        yield return new TestCaseData(new[] { 1, 2, 3, 4 }).Returns(3);
        yield return new TestCaseData(new[] { 7, 1, 5, 3, 6, 4 }).Returns(5);
    }

    [TestCaseSource(nameof(MaxProfitTestCases))]
    public int TestMaxProfit(int[] nums)
    {
        return Challenges.MaxProfit(nums);
    }

    private static Renderer Renderer = new Renderer(new char[,] {
        {'1', '2', '3', '4', '5', '6', '7', '8', '9'},
        {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'},
        {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'},
        {'1', '2', '3', '4', '5', '6', '7', '8', '9'},
        {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'},
        {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'},
        {'1', '2', '3', '4', '5', '6', '7', '8', '9'},
        {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'},
        {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'},
    });

    public static IEnumerable RendererTestCases()
    {
        yield return new TestCaseData(1, 1, 9)
            .Returns(new char[,] {
                {'b', 'c', 'd'},
                {'B', 'C', 'D'},
                {'2', '3', '4'},
            });
        yield return new TestCaseData(2, 1, 3)
            .Returns(new char[,] {
                {'B', 'C', 'D'},
                {'2', '3', '4'},
                {'b', 'c', 'd'},
            });
        yield return new TestCaseData(2, 2, 3)
            .Returns(new char[,] {
                {'C', 'D', 'E'},
                {'3', '4', '5'},
                {'c', 'd', 'e'},
            }); 
        yield return new TestCaseData(3, 3, 5)
            .Returns(new char[,] {
                {'4', '5', '6'},
                {'d', 'e', 'f'},
                {'D', 'E', 'F'},
            }); 
    }

    [TestCaseSource(nameof(RendererTestCases))]
    public char[,] TestRenderer(int x, int y, int maxAcceptableSeconds)
    {
        var stopWatch = Stopwatch.StartNew();
        var result = Renderer.DisplayLocationAtScreen(x, y);
        stopWatch.Stop();
        Assert.That(
            stopWatch.Elapsed < TimeSpan.FromSeconds(maxAcceptableSeconds + 1),
            message: $"Expected method to take less than {maxAcceptableSeconds * 1000} milliseconds, but it took {stopWatch.Elapsed.TotalMilliseconds}."
        );
        return result;
    }

    public static IEnumerable DetermineMeetingRoomCountTestCases()
    {
        yield return new TestCaseData(new List<(TimeOnly, TimeOnly)>
            { 
                (new (7), new (9)),
                (new (8), new (10)),
                (new (9), new (10)),
            })
            .Returns(2);
        yield return new TestCaseData(new List<(TimeOnly, TimeOnly)>
            { 
                (new (9), new (9, 30)),
                (new (7), new (9)),
                (new (9, 30), new (10)),
            })
            .Returns(1);
        yield return new TestCaseData(new List<(TimeOnly, TimeOnly)>
            { 
                (new (9), new (9, 30)),
                (new (7), new (9)),
                (new (8), new (10)),
                (new (9, 30), new (10)),
            })
            .Returns(2);
        yield return new TestCaseData(new List<(TimeOnly, TimeOnly)>
            { 
                (new (9), new (9, 30)),
                (new (9), new (9, 30)),
                (new (9), new (9, 30)),
                (new (9, 30), new (10)),
            })
            .Returns(3);
    }

    [TestCaseSource(nameof(DetermineMeetingRoomCountTestCases))]
    public int TestDetermineMeetingRoomCount(List<(TimeOnly, TimeOnly)> meetings)
    {
        return Challenges.DetermineMeetingRoomCount(meetings);
    }
}