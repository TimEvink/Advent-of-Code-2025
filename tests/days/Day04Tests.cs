using Xunit;
using FluentAssertions;
using aoc2025.src.Days;
using aoc2025.src.interfaces;
using System;

namespace aoc2025.tests.Days;

public class Day04Tests {
    [Fact]
    public void getArrayTest() {
        var day = new Day04("testinput/day04/getarrayinput.txt");
        char[,] expected = new char[,] {
            {'.', '@', '.'},
            {'@', '.', '@'},
            {'.', '@', '.'}
        };
        day.getArray().Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void Example1Test() {
        var day = new Day04("testinput/day04/example.txt");
        Assert.Equal(13, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day04("testinput/day04/example.txt");
        Assert.Equal(43, day.SolvePart2());
    }
}
