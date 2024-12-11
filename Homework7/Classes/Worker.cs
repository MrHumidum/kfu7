using System;

namespace Homework7
{
    /// <summary>
    /// Класс Worker представляет рабочего, являющегося подтипом сотрудника.
    /// </summary>
    public class Worker : Employee
    {
        /// <summary>
        /// Конструктор для создания рабочего.
        /// </summary>
        /// <param name="name">Имя рабочего.</param>
        /// <param name="role">Роль или должность рабочего.</param>
        public Worker(string name, string role) : base(name, role) { }
    }

}