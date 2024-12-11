using System;

namespace Homework7
{
    /// <summary>
    /// Класс Manager представляет менеджера, который является подтипом сотрудника.
    /// Менеджер может управлять подчинёнными сотрудниками.
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Список подчинённых сотрудников.
        /// </summary>
        public List<Employee> Subordinates { get; } = new List<Employee>();

        /// <summary>
        /// Конструктор для создания менеджера.
        /// </summary>
        /// <param name="name">Имя менеджера.</param>
        /// <param name="role">Роль или должность менеджера.</param>
        public Manager(string name, string role) : base(name, role) { }

        /// <summary>
        /// Добавляет подчинённого сотрудника в список подчинённых.
        /// </summary>
        /// <param name="employee">Подчинённый сотрудник.</param>
        public void AddSubordinate(Employee employee)
        {
            Subordinates.Add(employee);
            employee.supervisor = this;
        }

        /// <summary>
        /// Добавляет несколько подчинённых сотрудников в список подчинённых.
        /// </summary>
        /// <param name="employees">Массив сотрудников, которые будут добавлены в список подчинённых.</param>
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