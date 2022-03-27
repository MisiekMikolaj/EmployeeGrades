using System;
using Xunit;
//using Challenge;



namespace Challenge.Tests;

public class EmplyeeTest
{
    [Fact]
    public void GetStatisticReturnsCorrectResult()
    {
        //average
        var emp = new Employee("Miki");
        emp.AddWorkingTime(2.5);
        emp.AddWorkingTime(5.2);
        emp.AddWorkingTime(4.3);
        
        //act
        var result = emp.GetStatistics();
        //asert
        Assert.Equal(4, result.AverageHouer);
        Assert.Equal(2.5, result.Low);
        Assert.Equal(5.2, result.High);

    }
    [Fact]
    public void EmployeeReturnsDifereentObects()
    {
        //average
        var emp1 = new Employee("Miki");
        var emp2 = new Employee("Tom");
        var emp3 = emp1;
        //act
        
        //asert
        Assert.Equal("Miki",emp1.Name);
        Assert.Equal("Tom",emp2.Name);
        Assert.NotSame(emp1, emp2);
        Assert.False(Object.ReferenceEquals(emp1, emp2));
        Assert.Same(emp1, emp3);
        Assert.True(Object.ReferenceEquals(emp1, emp3));
        Assert.True(Employee.ReferenceEquals(emp1, emp3));
        Assert.False(Employee.ReferenceEquals(emp1, emp2));
        Assert.False(Employee.ReferenceEquals(emp1, emp2));

    }
}