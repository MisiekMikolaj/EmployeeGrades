namespace Challenge
{
    public class Statistics
    {
        public double SumHouer;
        public double CountHouer;
        public double High;
        public double Low;
        public double SumGrades;
        public double CountGrades;

    public Statistics()
    {
        CountHouer = 0;
        SumHouer = 0.0;
        High = double.MinValue;
        Low = double.MaxValue;
        CountGrades = 0;
        SumGrades = 0.0;
    }

    public double AverageHouer
    {
        get
        {
            return SumHouer / CountHouer;
        }
    }

    public double AverageGrade
    {
        get
        {
            return SumGrades / CountGrades;
        }
    }

    public void AddGrade(double grade)
    {
        SumGrades += grade;
        CountGrades += 1;
    }
    public void AddStatistics(double number)
    {
        SumHouer += number;
        CountHouer += 1;
        High = Math.Max(number, High);
        Low = Math.Min(number, Low);

    }
        public void ShowStatistic(string name)
        {
            Console.WriteLine($"{name} \nMax: {High} Min: {Low} Average: {AverageHouer}");
        }

        public void ShowAverageGrade()
        {   
             Console.WriteLine($"Average of Grades {AverageGrade}");
        }
    }

    
}