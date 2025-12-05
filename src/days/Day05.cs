using System;
using System.IO;
using System.Collections.Generic;
using aoc2025.src.interfaces;
using System.Linq;

namespace aoc2025.src.Days;
public class Day05 : IDay {
    private readonly string _inputPath;
    public Day05(string inputPath = "") {
        _inputPath = inputPath;
    }

    public IEnumerable<(long, long)> GetBounds() {
        foreach (string line in File.ReadLines(_inputPath)) {
            if (line == "") break;
            string[] parts = line.Split('-');
            yield return (long.Parse(parts[0]), long.Parse(parts[1]));
        }
    }

    public IEnumerable<long> GetIDs() {
        bool emptylineflag = false;
        foreach (string line in File.ReadLines(_inputPath)) {
            if (line == "") {
                emptylineflag = true;
                continue;
            }
            if (emptylineflag) yield return long.Parse(line);
        }
    }

    public object SolvePart1() {
        (long, long)[] bounds = [.. GetBounds()];
        int freshcount = 0;
        foreach (long ID in GetIDs()) {
            foreach (var (lower, upper) in bounds) {
                if (lower <= ID && ID <= upper) {
                    freshcount += 1;
                    break;
                }
            }
        }
        return freshcount;
    }

    public static (long, long)? JoinRanges((long, long) range1, (long, long) range2) {
        //checks for overlap of the 2 intervals
        if (range2.Item1 <= range1.Item2 && range1.Item1 <= range2.Item2) {
            return (Math.Min(range1.Item1, range2.Item1), Math.Max(range1.Item2, range2.Item2));
        }
        return null;
    }

    public object SolvePart2() {
        List<(long, long)> ranges = GetBounds().ToList();
        int n = ranges.Count;
        ResetForLoops:; 
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                (long, long)? newrange = JoinRanges(ranges[i], ranges[j]);
                if (newrange == null) continue;
                ranges[i] = newrange.Value;
                ranges.RemoveAt(j);
                n -= 1;
                goto ResetForLoops;
            }
        }
        return ranges.Sum(range => range.Item2 - range.Item1 + 1);
    }
}
