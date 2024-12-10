using System;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Написать программу, содержащую решение следующих задач:
            // На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что
            // решили, что будут получать задачи только в том случае, если это их прямое руководство.
            // Все возмущение началось из‐за того, что бухгалтерия решила автоматизировать себе работу,
            // они хотят приходить на работу, нажимать на кнопочку и чтобы все само делалось, а отдел
            // информационных технологий должен сделать эту задачу им. Перейдем к иерархии сотрудников:
            // Главный в конторе Тимур – генеральный директор.
            // У Тимура есть подчиненные:
            // Финансовый директор – Рашид,
            // Директор по автоматизации – О Ильхам.
            // Рашид в подчинении держит бухгалтерию.В бухгалтерии главный Лукас.
            // О Ильхам в подчинении держит отдел информационных технологий. В отделе
            // информационных технологий следующая иерархия: существует начальник, зам.
            // начальника и 2 сектора.
            // Начальник инф систем – Оркадий
            // Зам.начальника – Володя.
            // ○ системщики(занимаются сетями).Главный в секторе системщиков: Ильшат,
            // Зам: Иваныч, Сотрудники: Илья, Витя, Женя
            // ○ разработчики(разработка и сопровождение).Главный секторе разработчиков:
            // Сергей, Зам: Ляйсан, Сотрудники: Марат, Дина , Ильдар, Антон.
            // Таким образом, Дина, Марат, Ильдар, Антон слушаются Ляйсан, Ляйсан слушается
            // только Сергея, Сергей может слушаться Оркадия и Володю. Аналогично и с
            // сектором системщиков.Организовать иерархию конторы, создать несколько примитивых задач.
            // При назначении задач, задача должна иметь признак кому ее дают: системщикам или
            // разработчикам или начальству(начальник и зам.начальник отдела), а потом
            // распределить задачи по сотрудникам. На экране будет следующее: от человека А
            // даётся задача «название задачи» человек Б. И надо вывести берет человек задачу или нет.

            Manager generalManager = new Manager("Тимур", "Генеральный директор");
            Manager financialDirector = new Manager("Рашид", "Финансовый директор");
            Manager directorOfAutomation = new Manager("Ильхам", "Директор по автоматизации");

            generalManager.AddSubordinate(financialDirector, directorOfAutomation);

            Manager chiefAccountant = new Manager("Лукас", "Главный бухгалтер");
            financialDirector.AddSubordinate(chiefAccountant);

            Manager headOfInfSystems = new Manager("Оркадий", "Начальник инф систем");
            Manager deputyHeadOfInfSystems = new Manager("Володя", "Зам Начальник инф систем");

            directorOfAutomation.AddSubordinate(headOfInfSystems, deputyHeadOfInfSystems);

            // Системщики
            Manager networkSectorHead = new Manager("Ильшат", "Главный системщиков");
            Manager networkSectorDeputyHead = new Manager("Иваныч", "Зам. системщиков");
            Manager networkEmployee1 = new Manager("Илья", "Системщик");
            Manager networkEmployee2 = new Manager("Витя", "Системщик");
            Manager networkEmployee3 = new Manager("Женя", "Системщик");

            headOfInfSystems.AddSubordinate(networkSectorHead);
            networkSectorHead.AddSubordinate(networkSectorDeputyHead, networkEmployee1, networkEmployee2, networkEmployee3);

            // Разработчики
            Manager developerSectorHead = new Manager("Сергей", "Главный разработчик");
            Manager developerSectorDeputyHead = new Manager("Ляйсан", "Зам. разработчик");
            Manager developer1 = new Manager("Марат", "Разработчик");
            Manager developer2 = new Manager("Дина", "Разработчик");
            Manager developer3 = new Manager("Ильдар", "Разработчик");
            Manager developer4 = new Manager("Антон", "Разработчик");

            deputyHeadOfInfSystems.AddSubordinate(developerSectorHead);
            developerSectorHead.AddSubordinate(developerSectorDeputyHead);
            developerSectorDeputyHead.AddSubordinate(developer1, developer2, developer3, developer4);

            // Назначение задач
            generalManager.AssignTask("Подготовить годовой отчёт", financialDirector);
            financialDirector.AssignTask("Сделать отчёт по финансам", chiefAccountant);
            directorOfAutomation.AssignTask("Автоматизировать процессы", headOfInfSystems);
            headOfInfSystems.AssignTask("Проверить оборудование", networkSectorHead);
            networkSectorHead.AssignTask("Ремонт серверов", networkEmployee1);

            // Тест на задачу, которую не следует брать
            chiefAccountant.AssignTask("Сдать отчёт директору", developer1); // Не может взять задачу
        }
    }
}


