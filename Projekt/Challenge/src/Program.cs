using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge
{
    class Program 
    {         
        static void Main(string[] args)
        {
            List<string> week = new List<string>{"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
            bool succes = false;
            int HowManyEmployees = 0;
            
            while (!succes)
            {
            Console.WriteLine("How many employees do you have?");
            succes = int.TryParse(Console.ReadLine(), out HowManyEmployees);
            }
                       
            List<Employee> employee = new List<Employee>();
            List<SaveEmployeeFile> file = new List<SaveEmployeeFile>();
            for (int i=0; i<HowManyEmployees; i++)
            {
                Console.WriteLine($"Give the employee's name with the index {i}");
                employee.Add(new Employee(Console.ReadLine()));
                file.Add(new SaveEmployeeFile(employee[i].Name));
                employee[i].NotFullTimeAtWork += WarningNotFullTimeAtWork;
                file[i].NotFullTimeAtWork += WarningNotFullTimeAtWork;
                
                Console.WriteLine("How many hours did he/SHE work this week? ");
                for (int j=0; j<6;j++)
                {
                    Console.WriteLine(week[j]);
                    var inputHouers = Console.ReadLine();
                    try
                    {
                        employee[i].AddWorkingTime(inputHouers);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    try
                    {
                        file[i].AddWorkingTime(inputHouers);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                Console.WriteLine($"\nRate {employee[i].Name} for this Week"); 
                try
                {
                    employee[i].AddGrade(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (employee[i].Grades.Count != 0)
                {
                    file[i].AddGradeFromMemory(employee[i].Grades[0]);       
                }            
            }
            Console.WriteLine("\nStatistics from this Week");
            foreach (var i in employee)
            { 
                i.GetStatistics().ShowStatistic(i.Name);
                i.GetGrade().ShowAverageGrade();
            }

            Console.WriteLine("\nStatistics from all Weeks");
            foreach (var i in file)
            { 
                i.GetStatistics().ShowStatistic(i.Name);
                i.AverageGrades().ShowAverageGrade();
            }
        }

        static void WarningNotFullTimeAtWork(object employee, EventArgs arg)
        {
            Console.WriteLine("His/Her Bonus price should be lower");
        }
    }
}