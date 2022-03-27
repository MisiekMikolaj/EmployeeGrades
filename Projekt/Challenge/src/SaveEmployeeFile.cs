namespace Challenge
{
    public class SaveEmployeeFile: EmployeeBase
    {
        const string FileNameName = "_Houers.txt";
        const string FileNameAudit = "_Audit.txt";
        const string FileNameGrade = "_Grades.txt";
        public SaveEmployeeFile(string name) : base (name)
        {   
            using (var writer = File.AppendText($"{Name}{FileNameName}"))
            {                        
            }
            using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
            {                        
            }
            using (var writer = File.AppendText($"{Name}{FileNameGrade}"))
            {                        
            }
        }
        public delegate void NotFullTimeAtWorkDelegate (object employee, EventArgs args);
        
        public event NotFullTimeAtWorkDelegate NotFullTimeAtWork;
        public override void AddWorkingTime(double grade)
        {
            throw new NotImplementedException();
        }
        public void AddGradeFromMemory(double grade)
        {
            using (var writer = File.AppendText($"{Name}{FileNameGrade}"))
            {
            writer.WriteLine(grade);
            }
        }
        public override bool SetName(string NewName)
        {
            throw new NotImplementedException();
        }
        public override void AddGrade(string grade)
        {
            base.AddGrade(grade);
        }

        public override void AddWorkingTime(string houer)
        {   
            var ContractualTimeWork = 8;
            if (int.TryParse(houer, out var result) == true)
            {
                if (result>=0 && result<= 12)
                {
                    using (var writer = File.AppendText($"{Name}{FileNameName}"))
                    {
                        writer.WriteLine(houer);
                    }
                    using (var writer = File.AppendText($"{Name}{FileNameAudit}"))
                    {
                        writer.WriteLine(houer + " at time: " + DateTime.UtcNow );
                    }
                    if (result<ContractualTimeWork)
                    {
                        if (NotFullTimeAtWork != null)
                        {
                            NotFullTimeAtWork(this, new EventArgs());
                        }
                    }
                }
                else
                {
                    throw new ArgumentException ($"Invalid Argument {nameof(houer)}");
                } 
            } 
        }
        public Statistics AverageGrades()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}{FileNameGrade}"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var grade = double.Parse(line);
                    result.AddGrade(grade);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}{FileNameName}"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.AddStatistics(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}