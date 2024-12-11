using System;

namespace zadanie
{
    /// <summary>
    /// Класс QueueManager управляет очередью жителей для распределения их по окнам жэка.
    /// </summary>
    class QueueManager
    {
        /// <summary>
        /// Стек для работы с Зиной, в который добавляются все жители перед распределением.
        /// </summary>
        private Stack<Citizen> zinaStack = new Stack<Citizen>();

        // <summary>
        /// Очередь для первого окна (решение проблем с отоплением).
        /// </summary>
        private Queue<Citizen> heatingQueue = new Queue<Citizen>();

        /// <summary>
        /// Очередь для второго окна (решение проблем с оплатой отопления).
        /// </summary>
        private Queue<Citizen> paymentQueue = new Queue<Citizen>();

        /// <summary>
        /// Очередь для третьего окна (решение прочих вопросов).
        /// </summary>
        private Queue<Citizen> otherQueue = new Queue<Citizen>();

        /// <summary>
        /// Генератор случайных чисел для имитации случайного поведения "тупых" жителей.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Добавляет жителя в стек Зины.
        /// </summary>
        /// <param name="citizen">Объект класса Citizen, представляющий жителя.</param>
        public void AddToQueue(Citizen citizen)
        {
            zinaStack.Push(citizen);
        }

        /// <summary>
        /// Обрабатывает стек Зины и распределяет жителей по окнам в зависимости от их характеристик.
        /// </summary>
        public void ProcessQueue()
        {
            while (zinaStack.Count > 0)
            {
                Citizen citizen = zinaStack.Pop();

                if (citizen.temperament.intelligence == 0)
                {
                    int randomQueue = random.Next(1, 4);
                    AddToWindowQueue(citizen, randomQueue);
                }
                else
                {
                    AddToWindowQueue(citizen, citizen.problemNumber);
                }
            }
        }

        /// <summary>
        /// Добавляет жителя в соответствующую очередь.
        /// Если скандальность >= 5, житель обгоняет очередь.
        /// </summary>
        /// <param name="citizen">Объект класса Citizen, представляющий жителя.</param>
        /// <param name="windowNumber">Номер окна (1 - отопление, 2 - оплата, 3 - прочее).</param>
        private void AddToWindowQueue(Citizen citizen, int windowNumber)
        {
            if (citizen.temperament.scandalousness >= 5)
            {
                Console.WriteLine($"{citizen.name} обгоняет очередь!");

                switch (windowNumber)
                {
                    case 1:
                        ObstructQueue(heatingQueue, citizen);
                        break;
                    case 2:
                        ObstructQueue(paymentQueue, citizen);
                        break;
                    case 3:
                        ObstructQueue(otherQueue, citizen);
                        break;
                }
            }
            else
            {
                switch (windowNumber)
                {
                    case 1:
                        heatingQueue.Enqueue(citizen);
                        break;
                    case 2:
                        paymentQueue.Enqueue(citizen);
                        break;
                    case 3:
                        otherQueue.Enqueue(citizen);
                        break;
                }
            }
        }

        /// <summary>
        /// Перемещает жителя в начало очереди, сохраняя порядок остальных.
        /// </summary>
        /// <param name="queue">Очередь, в которую добавляется житель.</param>
        /// <param name="citizen">Объект класса Citizen, представляющий жителя.</param>
        private void ObstructQueue(Queue<Citizen> queue, Citizen citizen)
        {
            List<Citizen> tempList = new List<Citizen>(queue);
            queue.Clear();
            queue.Enqueue(citizen);
            foreach (var person in tempList)
            {
                queue.Enqueue(person);
            }
        }

        /// <summary>
        /// Выводит на экран содержимое всех очередей.
        /// </summary>
        public void PrintQueues()
        {
            Console.WriteLine("\nОчередь к окну 1 (отопление):");
            PrintQueue(heatingQueue);

            Console.WriteLine("\nОчередь к окну 2 (оплата):");
            PrintQueue(paymentQueue);

            Console.WriteLine("\nОчередь к окну 3 (прочее):");
            PrintQueue(otherQueue);
        }

        /// <summary>
        /// Выводит на экран содержимое указанной очереди.
        /// </summary>
        /// <param name="queue">Очередь для вывода.</param>
        private void PrintQueue(Queue<Citizen> queue)
        {
            foreach (var citizen in queue)
            {
                Console.WriteLine($"- {citizen.name} (Скандальность: {citizen.temperament.scandalousness})");
            }
        }
    }
}
