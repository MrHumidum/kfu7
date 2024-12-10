using System;

namespace Homework7
{
    public class Manager : Employee
    {
        public List<Employee> Subordinates { get; } = new List<Employee>();

        public Manager(string name, string role) : base(name, role) { }

        public void AddSubordinate(Employee employee)
        {
            Subordinates.Add(employee);
            employee.supervisor = this;
        }

        public void AddSubordinate(params Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Subordinates.Add(employees[i]);
                employees[i].supervisor = this;
            }
        }
    }
}