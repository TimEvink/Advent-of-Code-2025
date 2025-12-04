using System;
using System.IO;
using aoc2025.src.interfaces;
using aoc2025.src.utils;

namespace aoc2025.src.Days;
public class Day01 : IDay {
    private readonly string _inputPath;
    public Day01(string inputPath = "") {
        _inputPath = inputPath;
    }
    public object SolvePart1() {
        int counter = 0;
        int position = 50;
        foreach (string line in File.ReadLines(_inputPath)) {
            int sign = line[0] == 'R' ? 1 : -1;
            int increment = int.Parse(line[1..]);
            position += sign * increment;
            position %= 100;
            if (position == 0) {
                counter += 1;
            }
        }
        return counter;
    }
    public object SolvePart2() {
        int counter = 0;
        int position = 50;
        int newposition;
        foreach (string line in File.ReadLines(_inputPath)) {
            int increment = int.Parse(line[1..]);
            newposition = line[0] == 'R' ? position + increment : position - increment;

            //goal is to determine the number of multiples of 100 in between the old and new position.
            int min = Math.Min(position, newposition);
            int max = Math.Max(position, newposition);
            int lower = min % 100 == 0 ? min : min - MathUtils.TrueMod(min, 100) + 100;
            int upper = max % 100 == 0 ? max : max - MathUtils.TrueMod(max, 100);
            if (lower <= upper) {
                counter += (upper - lower) / 100 + 1;
            }
            //correct for double counting: if old position is 0 it will be counted by the above again
            if (position == 0) {
                counter -= 1;
            }
            position = MathUtils.TrueMod(newposition, 100);
        }
        return counter;
    }
}
