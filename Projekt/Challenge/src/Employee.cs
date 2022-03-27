namespace Challenge
{
    public class Employee : EmployeeBase
    {        
        private List<double> houersAtWork = new List<double>();
        private List<double> grades = new List<double>();
        private string sex;
        public delegate void NotFullTimeAtWorkDelegate (object employee, EventArgs args);
        
        public event NotFullTimeAtWorkDelegate NotFullTimeAtWork;
        
        new public void WriteString(string String)
        {
            base.WriteString(String);
        }
        public Employee(string name, string sex): base(name)
        {
            this.Name = name;
            this.Sex = sex;           
        }

        public Employee(string name): base(name)
        {
            this.Name = name;
        }
        public List<double> HouersAtWork
        { 
            get
            {
                return this.houersAtWork;
            }    
        }
        public List<double> Grades
        { 
            get
            {
                return this.grades;
            }    
        }
        public string Sex 
        { 
            get
            {
                return this.sex;
            }
            set
            {   
                this.sex = value;
            }
        }

        public override bool SetName(string NewName)
        {
                var Numbers = 0;
                var CheckingNumbers = true;                              

                foreach (var letter in NewName)
                {
                    if (char.IsDigit(letter)==true)
                    {
                        Numbers++;
                    }                                    
                }

                if (Numbers == 0)
                {
                    CheckingNumbers = false;
                    this.Name = NewName;
                }
                
                else
                {
                    Console.WriteLine("Imie nie może zawierać cyfr");
                }
            return CheckingNumbers; 
        }

        public override void AddWorkingTime(double houer)
        {
            this.houersAtWork.Add(houer);
        }

        public override void AddWorkingTime(string houer)
        {   
            var ContractualTimeWork = 8;
            if (int.TryParse(houer, out var result) == true)
            {
                if (result>=0 && result<= 12)
                {
                    this.houersAtWork.Add(result);
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
                    throw new ArgumentException ($"Invalid Argument {nameof(result)}");
                } 
            }        
        }


        public override void AddGrade(string grade)
        {   
            switch(grade)
            {
                case "1+":
                    this.grades.Add(1.5);
                    break;

                case "2+":
                    this.grades.Add(2.5);
                    break;

                case "3+":
                    this.grades.Add(3.5);
                    break;

                case "4+":
                    this.grades.Add(4.5);
                    break;

                case "5+":
                    this.grades.Add(5.5);
                    break;

                case "1-":
                    this.grades.Add(0.75);
                    break;

                case "2-":
                    this.grades.Add(1.75);
                    break;

                case "3-":
                    this.grades.Add(2.75);
                    break;

                case "4-":
                    this.grades.Add(3.75);
                    break;
                
                case "5-":
                    this.grades.Add(4.75);
                    break;

                case "6-":
                    this.grades.Add(5.75);
                    break;

                case "1":
                    this.grades.Add(1);
                    break;

                case "2":
                    this.grades.Add(2);
                    break;

                case "3":
                    this.grades.Add(3);
                    break;

                case "4":
                    this.grades.Add(4);
                    break;
                
                case "5":
                    this.grades.Add(5);
                    break;

                case "6":
                    this.grades.Add(6);
                    break;

                default:
                    throw new ArgumentException ($"Invalid Argument {nameof(grade)}");
                    

            }
        }
        public Statistics GetGrade()        
        {
            var result = new Statistics();
            
            for(var index = 0; index < grades.Count; index += 1)
            {
                result.AddGrade(grades[index]);
            }
        
            return result;            
        }
        public override Statistics GetStatistics()        
        {
            var result = new Statistics();
            
            for(var index = 0; index < houersAtWork.Count; index += 1)
            {
                result.AddStatistics(houersAtWork[index]);
            }
        
            return result;            
        }

        public bool AddWorkingTimeFullOption(string grade)
        {   var result = 0.0;
            double symbolValue;
            bool succes = false;

            switch(grade[grade.Length-1])
            {
                case '+':
                    grade = grade.Replace("+", "");
                    symbolValue = 0.5;
                    break;

                case '-':
                    grade = grade.Replace("-", "");
                    symbolValue = -0.25;
                        break;

                default:
                    symbolValue = 0;
                    break;

            }                    
            succes = double.TryParse(grade, out result);

            if (result%1 == 0)
            {
                result += symbolValue;
            }

            else if((symbolValue == 0.5 || symbolValue == -0.25) && result%1 != 0 )
            {
                succes = false;
            }            
                    
                    
            if (result>=0 && result<= 12 && succes == true)
            {
                this.houersAtWork.Add(result);
            }

            else if ((result<=0 || result>= 12) && succes == true)
            {
                throw new ArgumentException ($"Invalid Argument {nameof(result)}");
            }
                    
                
            return succes;
        }
    }
}