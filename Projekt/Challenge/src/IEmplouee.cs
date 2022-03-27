namespace Challenge
{
    public interface IEmployee
    {
        void AddWorkingTime(double grade);
        Statistics GetStatistics();
        bool SetName(string NewName);
        string Name{get;set;}
        void AddGrade(string grade);
        void WriteString(string String);
    }
}