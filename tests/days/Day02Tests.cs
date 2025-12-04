using Xunit;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day02Tests {
    [Fact]
    public void Example1Test() {
        var day = new Day02("testinput/day02/example.txt");
        Assert.Equal((long) 1227775554, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day02("testinput/day02/example.txt");
        Assert.Equal((long) 4174379265, day.SolvePart2());
    }
}
