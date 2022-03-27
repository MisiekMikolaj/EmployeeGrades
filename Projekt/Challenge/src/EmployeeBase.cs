namespace Challenge
{
    public abstract class EmployeeBase : NamedObject, IEmployee
    {
        
        
        public EmployeeBase(string name) : base(name)
        { 
        }
        public virtual void AddGrade(string grade)
        {
            throw new NotImplementedException();
        }
        public abstract void AddWorkingTime (double grade);
        public abstract void AddWorkingTime (string grade);
        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
        public abstract bool SetName(string NewName);
        new public void WriteString(string String)
        {
            base.WriteString(String);
        }
    }
}