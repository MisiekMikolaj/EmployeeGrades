using System;
using Xunit;
using Challenge;



namespace Challenge.Tests;

public class TypeTests
{
    public delegate string WritteMessage(string mssage);

    [Fact]
    public void WritteMessageDelegateCanPointToMethod()
    {
        WritteMessage del;
        del = returnMessage;
        var result = del("Hello");
        Assert.Equal("Hello",result);
    }

    String returnMessage(string message)
    {
        return message;
    }

    [Fact]
    public void GetEmployeeReturnsDifereentObects()
    {
        var emp1 = GetEmployee("Miki");
        var emp2 = GetEmployee("Tom");

        Assert.Equal("Miki",emp1.Name);
        Assert.Equal("Tom",emp2.Name);
        Assert.NotSame(emp1, emp2);
        Assert.False(Object.ReferenceEquals(emp1, emp2));
    }
    [Fact]
    public void CanSetNameFromReference()
    {
        var emp1 = GetEmployee("Miki");
        this.SetName(emp1, "NewName");
        Assert.Equal("NewName", emp1.Name);
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        var emp1 = GetEmployee("Miki");
        GetEmployeeSetName(out emp1, "NewName");
        Assert.Equal("NewName", emp1.Name);
    }
   
   private Employee GetEmployee(string name)
   {
       return new Employee(name);
   }

   private void GetEmployeeSetName(out Employee emp, string name)
   {
       emp = new Employee(name);
   }

   private void SetName(Employee employee, string name)
   {
       employee.Name = name;
   }

   [Fact]
    public void Test1()
    {
        var x = GetInt();
        SetInt(ref x);
        

        Assert.Equal(42, x);
    }

    private void SetInt( ref int x)
    {
        x = 42;
    }

    private int GetInt()
    {
        return 3;
    }
}