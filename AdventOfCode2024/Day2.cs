class Day2
{

    bool IsSafe(List<int> report)
    {
        bool increaseing = report[0] < report[report.Count - 1];

        for (int i = 0; i < report.Count - 1; i++)
        {
            int distance =  report[i + 1] - report[i] ;
            
            if (Math.Abs(distance) > 3 || Math.Abs(distance) < 1)
            {
                return false;
            }

            if( increaseing && distance <= 0){
                return false;
            }
            else if(!increaseing && distance >= 0){
                return false;
            }
        }
        return true;
    }

    bool IsSafeWithDampener(List<int> report)
    {
        if (IsSafe(report))
        {
            return true;
        }

        for (int i = 0; i < report.Count; i++)
        {
            List<int> subReport = new List<int>(report);
            subReport.RemoveAt(i);
            if (IsSafe(subReport) )
            {
                return true;
            }
        }
        return false;
    }

    public void Solve()
    {
        List<List<int>> reports = new List<List<int>>()
        {
            // new List<int>() {7, 6, 4, 2, 1},
            // new List<int>() {1, 2, 7, 8, 9},
            // new List<int>() {9, 7, 6, 2, 1},
            // new List<int>() {1, 3, 2, 4, 5},
            // new List<int>() {8, 6, 4, 4, 1},
            // new List<int>() {1, 3, 6, 7, 9},
        };

        File.ReadAllLines("day2_input.txt").ToList().ForEach(line =>
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int> report = new List<int>();
            foreach (var part in parts)
            {
                report.Add(int.Parse(part));
            }
            reports.Add(report);
        });

        Console.WriteLine($"Number of safe reports: {reports.Count(IsSafe)} (Part 1)");
        Console.WriteLine($"Number of safe reports considering the dampener: {reports.Count(IsSafeWithDampener)} (Part 2)");
    }
}