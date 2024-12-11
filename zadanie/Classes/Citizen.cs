using System;

namespace zadanie
{
    /// <summary>
    /// Класс Citizen представляет жителя с его личными данными, проблемой и характеристиками темперамента.
    /// </summary>
    class Citizen
    {
        /// <summary>
        /// Имя жителя.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// Уникальный номер паспорта жителя.
        /// </summary>
        private Guid passportNumber = Guid.NewGuid();

        /// <summary>
        /// Описание проблемы, с которой житель обратился в жэк.
        /// </summary>
        public string problem;

        /// <summary>
        /// Номер категории проблемы (1 - отопление, 2 - оплата, 3 - прочее).
        /// </summary>
        public int problemNumber { get; private set; }

        /// <summary>
        /// Темперамент жителя, включающий скандальность и интеллект.
        /// </summary>
        public Temperament temperament { get; private set; }

        /// <summary>
        /// Конструктор для создания экземпляра жителя.
        /// </summary>
        /// <param name="name">Имя жителя.</param>
        /// <param name="problem">Описание проблемы.</param>
        /// <param name="scandalousness">Уровень скандальности (0-10).</param>
        /// <param name="intelligence">Интеллект (1 - умный, 0 - глупый).</param>
        public Citizen(string name, string problem, int scandalousness, int intelligence)
        {
            this.name = name;
            this.problem = problem;
            this.temperament = new Temperament(scandalousness, intelligence);
            this.problemNumber = SetProblemNumber(problem);
        }

        /// <summary>
        /// Определяет номер категории проблемы на основе ключевых слов в описании.
        /// </summary>
        /// <param name="problem">Описание проблемы.</param>
        /// <returns>Номер категории проблемы (1 - отопление, 2 - оплата, 3 - прочее).</returns>
        private int SetProblemNumber(string problem)
        {
            int num = 3;
            if (problem.Contains("плат"))
            {
                num = 2;
            }
            else if (problem.Contains("отоп"))
            {
                num = 1;

            }
            return num;
        }

        /// <summary>
        /// Выводит информацию о жителе на консоль.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {name}\nНомер паспорта: {passportNumber}\nПроблема: \"{problem}\"\nНомер проблемы: {problemNumber}");
            temperament.PrintTemperament();
        }


    }
}