using System;
using System.IO;
using System.Collections.Generic;
using aoc2025.src.interfaces;
using aoc2025.src.utils;

namespace aoc2025.src.Days;
public class Day04 : IDay {
    private readonly string _inputPath;
    public Day04(string inputPath = "") {
        _inputPath = inputPath;
    }

    public static readonly (int row, int col)[] Directions = new (int, int)[] {
        (-1, 1),
        (0, 1),
        (1, 1),
        (1, 0),
        (1, -1),
        (0, -1),
        (-1, -1),
        (-1, 0)
    };
    public char[,] getArray() {
        string[] lines = File.ReadAllLines(_inputPath);
        int rowLength = lines.Length;
        int columnLength = lines[0].Length;
        char[,] result = new char[rowLength, columnLength];
        for (int i = 0; i < rowLength; i++) {
            for (int j = 0; j < columnLength; j++) {
                result[i, j] = lines[i][j];
            }
        }
        return result;
    }

    public int countNeighbors(char[,] array, int i, int j) {
        int adjacentcount = 0;
        foreach (var (row, col) in Directions) {
            if (0 <= i + row && i + row < array.GetLength(0) &&
                0 <= j + col && j + col < array.GetLength(1) &&
                array[i + row, j + col] == '@') {
                adjacentcount += 1;
            }
        }
        return adjacentcount;
    }

    public object SolvePart1() {
        var array = getArray();
        int accessibleCount = 0;
        int rowLength = array.GetLength(0);
        int columnLength = array.GetLength(1);
        for (int i = 0; i < rowLength; i++) {
            for (int j = 0; j < columnLength; j++) {
                if (array[i, j] == '.') continue;
                if (countNeighbors(array, i, j) < 4) accessibleCount += 1;
            }
        }
        return accessibleCount;
    }
    public object SolvePart2() {
        var array = getArray();
        int rowLength = array.GetLength(0);
        int columnLength = array.GetLength(1);
        List<(int, int)> toBeRemoved = new();
        int removedcount = 0;
        while (true) {
            for (int i = 0; i < rowLength; i++) {
                for (int j = 0; j < columnLength; j++) {
                    if (array[i, j] == '.') continue;
                    if (countNeighbors(array, i, j) < 4) toBeRemoved.Add((i, j));
                }
            }
            foreach (var (i, j) in toBeRemoved) array[i, j] = '.';
            removedcount += toBeRemoved.Count;
            if (toBeRemoved.Count == 0) break;
            toBeRemoved.Clear();
        }
        return removedcount;
    }
}
