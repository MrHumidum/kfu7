using System;

namespace zadanie
{
    /// <summary>
    /// Структура Temperament характеризует темперамент жителя.
    /// </summary>
    struct Temperament
    {
        /// <summary>
        /// Уровень скандальности (0 - паинька, 10 - максимальный скандалист).
        /// </summary>
        public int scandalousness;

        /// <summary>
        /// Интеллект (1 - умный, 0 - глупый).
        /// </summary>
        public int intelligence;

        /// <summary>
        /// Конструктор для создания экземпляра структуры Temperament.
        /// </summary>
        /// <param name="scandalousness">Уровень скандальности (0-10).</param>
        /// <param name="intelligence">Интеллект (1 - умный, 0 - глупый).</param>
        /// <exception cref="ArgumentException">Выбрасывается, если скандальность вне диапазона 0-10 или интеллект не равен 0 или 1.</exception>
        public Temperament(int scandalousness, int intelligence)
        {
            if (scandalousness < 0 || scandalousness > 10)
            {
                throw new ArgumentException("Скандальность должна быть от 0 до 10");
            }
            if (intelligence != 0 && intelligence != 1)
            {
                throw new ArgumentException("Интеллект должен быть 0 или 1");
            }
            this.scandalousness = scandalousness;
            this.intelligence = intelligence;
        }

        /// <summary>
        /// Выводит информацию о темпераменте жителя в консоль.
        /// </summary>
        public void PrintTemperament()
        {
            Console.WriteLine($"Скандальность: {scandalousness}\nИнтеллект: {intelligence}");
        }
    }
}