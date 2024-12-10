using System;

namespace Homework7
{
    public abstract class Employee
    {
        public string name;
        public string role;
        public Employee supervisor;

        protected Employee(string name, string role)
        {
            this.name = name;
            this.role = role;
        }

        public bool AssignTask(string task, Employee from)
        {
            if (from == supervisor)
            {
                Console.WriteLine($"{from.name} даёт задачу '{task}' {name}. {name} берёт задачу.");
                return true;
            }
            else
            {
                Console.WriteLine($"{from.name} даёт задачу '{task}' {name}. {name} не берёт задачу.");
                return false;
            }
        }
    }
}
