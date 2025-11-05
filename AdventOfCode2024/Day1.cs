// public namespace AdventOfCode2024;
class Day1
{
    public void Solve()
    {
        List<int> leftLocations = new List<int>()
        {
            // 3,4,2,1,3,3
        };
        List<int> rightLocations = new List<int>()
        {
            // 4,3,5,3,9,3
        };

        string[] lines = File.ReadAllLines("day1_input.txt");

        foreach (var line in lines)
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            leftLocations.Add(int.Parse(parts[0]));
            rightLocations.Add(int.Parse(parts[1]));
        }

        leftLocations.Sort();
        rightLocations.Sort();

        int distance = 0;
        int similarityScore = 0;
        for (int i = 0; i < leftLocations.Count(); i++)
        {
            distance += Math.Abs(leftLocations[i] - rightLocations[i]);
            similarityScore += leftLocations[i] * rightLocations.Where(e => e.Equals(leftLocations[i])).Count();

            Console.WriteLine($"Distance between {leftLocations[i]} and {rightLocations[i]} is {Math.Abs(leftLocations[i] - rightLocations[i])}");
            Console.WriteLine($"Location {leftLocations[i]} has similarity score of {leftLocations[i] * rightLocations.Where(e => e.Equals(leftLocations[i])).Count()}");
        }

        Console.WriteLine($"Total distance: {distance} (Part 1)");
        Console.WriteLine($"Total similarity score: {similarityScore} (Part 2)");
    }
}
