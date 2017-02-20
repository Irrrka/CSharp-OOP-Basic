using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
    }
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email = "n/a";
    public int age = -1;
}
public class Pr4_Startup
{
    static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        List<Employee> itSolutions = new List<Employee>();

        for (int i = 0; i < numberOfEmployees; i++)
        {
            string[] employeeInfo = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            Employee employee = new Employee
                (
                employeeInfo[0], 
                decimal.Parse(employeeInfo[1]), 
                employeeInfo[2], 
                employeeInfo[3]
                );
            if (employeeInfo.Length == 6)
            {
                employee.email = employeeInfo[4];
                employee.age = int.Parse(employeeInfo[5]);
            }
            else if (employeeInfo.Length == 5 && employeeInfo[4].Contains("@"))
            {
                employee.email = employeeInfo[4];
            }
            else if (employeeInfo.Length == 5 && !employeeInfo[4].Contains("@"))
            {
                employee.age = int.Parse(employeeInfo[4]);
            }
            itSolutions.Add(employee);
        }
        Console.WriteLine();
        var result = itSolutions
                    .GroupBy(e => e.department)
                    .Select(x => new
                    {
                        Department = x.Key,
                        AverageSalary = x.Average(emp => emp.salary),
                        Employees = x.OrderByDescending(emp => emp.salary)
                    })
                    .FirstOrDefault();

        Console.WriteLine("Highest Average Salary: {0}", result.Department);

        foreach (var mployee in result.Employees)
        {
            Console.WriteLine("{0} {1} {2} {3}", mployee.name, mployee.salary, mployee.email, mployee.age);
        }
            
    }
}

