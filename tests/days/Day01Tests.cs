using Xunit;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day01Tests {
    [Fact]
    public void Example1Test() {
        var day = new Day01("testinput/day01/example.txt");
        Assert.Equal(3, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day01("testinput/day01/example.txt");
        Assert.Equal(6, day.SolvePart2());
    }
}
