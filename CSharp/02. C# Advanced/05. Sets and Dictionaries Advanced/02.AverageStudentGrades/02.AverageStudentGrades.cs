namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> gradesPerStudent = new();
            for (int i = 0; i < students; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!gradesPerStudent.ContainsKey(name))
                {
                    gradesPerStudent[name] = new List<decimal>();
                    gradesPerStudent[name].Add(grade);
                }
                else
                {
                    gradesPerStudent[name].Add(grade);
                }
            }
            foreach ((string student, List<decimal> grades) in gradesPerStudent)
            {
                string value = String.Join(" ", grades.Select(g => g.ToString("f2")));
                decimal average = grades.Average();
                Console.WriteLine($"{student} -> {value} (avg: {average:f2})");
            }
        }
    }
}
