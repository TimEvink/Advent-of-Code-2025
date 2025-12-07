using Xunit;
using System.Collections.Generic;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day07Tests {
    [Fact]
    public void ParseTest() {
        var day = new Day07("testinput/day07/parsetest.txt");
        string[] expected = new[] {
            "ahotjawelt",
            "iejrtsery"
        };
        Assert.Equivalent(expected, day.ParseInput());
    }

    [Fact]
    public void Example1Test() {
        var day = new Day07("testinput/day07/example.txt");
        Assert.Equal(21, day.SolvePart1());
    }

    [Fact]
    public void GenerateVerticesTest() {
        var day = new Day07("testinput/day07/generateverticestest.txt");
        var expected = new (int, int)[] {
            (0, 7),
            (1, 6),
            (1, 8),
            (2, 5),
            (2, 7),
            (2, 9),
            (3, 4),
            (3, 6),
            (3, 8),
            (3, 10),
            (4, 3),
            (4, 5),
            (4, 9),
            (4, 11)
        };
        Assert.Equal(expected, day.VerticesArray());
    }

    [Fact]
    public void GetNeighborsInTest() {
        var day = new Day07("testinput/day07/example.txt");
        var expected = new HashSet<(int, int)> {
            (2, 5),
            (2, 7)
        };
        Assert.Equal(expected, day.GetNeighborsIn((3, 6)));
    }

    [Fact]
    public void Example2Test() {
        var day = new Day07("testinput/day07/example.txt");
        Assert.Equal(40L, day.SolvePart2());
    }
}
