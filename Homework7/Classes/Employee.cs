using System;

namespace Homework7
{
    /// <summary>
    /// Абстрактный класс Employee представляет сотрудника в организации.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        public string name;

        /// <summary>
        /// Роль или должность сотрудника.
        /// </summary>
        public string role;

        /// <summary>
        /// Руководитель сотрудника.
        /// </summary>
        public Employee supervisor;

        /// <summary>
        /// Конструктор для создания экземпляра сотрудника.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="role">Роль или должность сотрудника.</param>
        protected Employee(string name, string role)
        {
            this.name = name;
            this.role = role;
        }

        /// <summary>
        /// Метод для передачи задачи сотруднику.
        /// </summary>
        /// <param name="task">Описание задачи.</param>
        /// <param name="from">Сотрудник, передающий задачу.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если задача принята, или <c>false</c>, если отклонена.
        /// </returns>
        /// <remarks>
        /// Сотрудник принимает задачу только от своего непосредственного руководителя.
        /// </remarks>
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
