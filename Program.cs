using System;
using System.Linq;
using System.Reflection;

static class Program {
    static void Main(string[] args) {
        int day;
        if (args.Length == 0) {
            Console.WriteLine("Defaulting to solution for day 1. For other days pass day number as optional parameter.");
            day = 1;
        } else if (int.TryParse(args[0], out var d)) {
            day = d;
        } else {
            Console.WriteLine($"Invalid day argument '{args[0]}', defaulting to solution for day 1.");
            day = 1;
        }
		string className = $"Day{day:D2}";
        Type? dayType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className && t.Namespace == "aoc2025.Days");
        if (dayType == null) {
            Console.WriteLine($"Day {day} not found.");
            return;
        }
        MethodInfo? part1Method = dayType.GetMethod("Part1", BindingFlags.Public | BindingFlags.Static);
        MethodInfo? part2Method = dayType.GetMethod("Part2", BindingFlags.Public | BindingFlags.Static);

        if (part1Method == null) {
            Console.WriteLine($"Part 1 of day {day} not implemented");
        }
        else {
            Console.WriteLine($"Running day {day}, part 1...");
            part1Method.Invoke(null, null);
        }
        if (part2Method == null) {
            Console.WriteLine($"Part 2 of day {day} not implemented");
        }
        else {
            Console.WriteLine($"Running day {day}, part 2...");
            part2Method.Invoke(null, null);
        }
    }
}
