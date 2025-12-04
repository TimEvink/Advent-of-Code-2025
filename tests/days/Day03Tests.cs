using Xunit;
using aoc2025.src.Days;
using System.Runtime.InteropServices;

namespace aoc2025.tests.Days;
public class Day03Tests {
    [Theory]
    [InlineData("59180", 2, 98)]
    [InlineData("781289", 3, 889)]
    [InlineData("871289", 4, 8789)]
    public void getMaxJoltageTest(string bank, int n, long expected) {
        Assert.Equal(expected, Day03.getMaxJoltage(bank, n));
    }

    [Fact]
    public void Example1Test() {
        var day = new Day03("testinput/day03/example.txt");
        Assert.Equal((long) 357, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day03("testinput/day03/example.txt");
        Assert.Equal((long) 3121910778619, day.SolvePart2());
    }
}
