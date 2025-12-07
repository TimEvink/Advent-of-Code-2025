using System.IO;
using System.Collections.Generic;
using aoc2025.src.interfaces;
using System.Linq;
using System;

namespace aoc2025.src.Days;
public class Day07 : IDay {
    private readonly string _inputPath;
    private string[]? _inputParsed;
    private HashSet<(int, int)>? _vertices;

    //lazy caching property
    public string[] InputParsed => _inputParsed ??= ParseInput();
    public HashSet<(int, int)> Vertices => _vertices ??= VerticesArray().ToHashSet();

    public Day07(string inputPath = "") {
        _inputPath = inputPath;
    }

    public string[] ParseInput() {
        bool flag = false;
        return File.ReadLines(_inputPath)
            .Where(_ => (flag = !flag))
            .ToArray();
    }

    public object SolvePart1() {
        int splitcounter = 0;
        HashSet<int> rowindices = new() { InputParsed[0].IndexOf('S') };
        for (int i = 0; i < InputParsed.Length - 1; i++) {
            HashSet<int> newindices = new();
            foreach (int j in rowindices) {
                if (InputParsed[i + 1][j] == '^') {
                    splitcounter += 1;
                    newindices.Add(j - 1);
                    newindices.Add(j + 1);
                }
                else {
                    newindices.Add(j);
                }
            }
            rowindices = newindices;
        }
        return splitcounter;
    }

    // For Part 2: we model the thing as a directed acyclic graph, the vertices being of type (int, int).\\
    // vertices are those positions (i,j) that are a starting point for a beam. I.e. input[i][j] of string[] input = ParseInput() is its either S or L/R adjacent to ^.
    // two vertices v, w have an edge v -> w precisely when a beam starting at v can end up at w by 1 split. Thus every vertix has either 0 or 2 outgoing edges.
    // Interpreted this way: we need to count the total number of paths going from S to any leaf in the graph.
    // In Part 1 the order of traversal gave us a topological ordering of the vertices, so we can count the paths incrementally using that order.

    public (int, int)[] VerticesArray() {
        var vertices = new List<(int, int)> { (0, InputParsed[0].IndexOf('S'))};
        HashSet<int> rowindices = new() { InputParsed[0].IndexOf('S') };
        for (int i = 0; i < InputParsed.Length - 1; i++) {
            HashSet<int> newindices = new();
            HashSet<int> newstarts = new();
            foreach (int j in rowindices) {
                if (InputParsed[i + 1][j] == '^') {
                    newindices.Add(j - 1);
                    newindices.Add(j + 1);
                    newstarts.Add(j - 1);
                    newstarts.Add(j + 1);
                }
                else {
                    newindices.Add(j);
                }
            }
            rowindices = newindices;
            (int, int)[] newarray = newstarts.Select(j => (i + 1, j)).ToArray();
            Array.Sort(newarray);
            vertices.AddRange(newarray);
        }
        return vertices.ToArray();
    }

    public HashSet<(int, int)> GetNeighborsIn((int, int) vertex) {
        HashSet<(int, int)> neighbors = new();
        foreach (int d in new[] { -1, 1 }) {
            try {
                if (InputParsed[vertex.Item1][vertex.Item2 + d] == '^') {
                    int k = 1;
                    while (vertex.Item1 - k >= 0) {
                        (int, int) candidate = (vertex.Item1 - k, vertex.Item2 + d);
                        if (InputParsed[candidate.Item1][candidate.Item2] == '^') break;
                        if (Vertices.Contains(candidate)) {
                            neighbors.Add(candidate);
                        }
                        k++;
                    }
                }
            }
            catch (System.IndexOutOfRangeException) { }
        }
        return neighbors;
    }
    
    //checks if the vertex doesnt have any outgoing neighbors, i.e. a leaf.
    public bool IsLeaf((int, int) vertex) {
        if (!Vertices.Contains(vertex)) return false;
        for (int i = vertex.Item1 + 1; i < InputParsed.Length; i++) {
            if (InputParsed[i][vertex.Item2] == '^') return false;
        }
        return true;
    }

    public object SolvePart2() {
        Dictionary<(int, int), long> pathcount = new();
        pathcount.Add((0, InputParsed[0].IndexOf('S')), 1);
        (int, int)[] vertices = VerticesArray();
        for (int i = 1; i < Vertices.Count; i++) {
            var vertex = vertices[i];
            pathcount[vertex] = GetNeighborsIn(vertex).Sum(v => pathcount[v]);
        }
        return pathcount.Where(v => IsLeaf(v.Key)).Sum(v => v.Value);
    }
}
