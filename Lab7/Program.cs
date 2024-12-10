using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            //             В класс банковский счет, созданный в упражнениях 7.1 - 7.3 добавить
            //             метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
            //             на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
            Console.WriteLine("Упражнение 8.1");
            Ex1();

            //             Реализовать метод, который в качестве входного параметра принимает
            //             строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            //             Протестировать метод.
            Console.WriteLine("Упражнение 8.2");
            Ex2();

            //             Написать программу, которая спрашивает у пользователя имя файла.Если
            //             такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            //             работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными буквами.
            Console.WriteLine("Упражнение 8.3");
            Ex3();

            //             Реализовать метод, который проверяет реализует ли входной параметр
            //             метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
            // IFormattable обеспечивает функциональные возможности форматирования значения объекта
            // в строковое представление.)
            Console.WriteLine("Упражнение 8.4");
            Ex4();



            //             Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail
            // адрес.Разделителем между ФИО и адресом электронной почты является символ #:
            // Иванов Иван Иванович # iviviv@mail.ru
            // Петров Петр Петрович # petr@mail.ru
            // Сформировать новый файл, содержащий список адресов электронной почты.
            // Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            // качестве параметра передается символьная строка s, e-mail возвращается в той же строке s.
            Console.WriteLine("Домашнее задание 8.1");
            Ex5();

            //             Список песен.В методе Main создать список из четырех песен.В
            // цикле вывести информацию о каждой песне.Сравнить между собой первую и вторую
            // песню в списке.Песня представляет собой класс с методами для заполнения каждого из
            // полей, методом вывода данных о песне на печать, методом, который сравнивает между
            // собой два объекта:

            Console.WriteLine("Домашнее задание 8.2");
            Ex6();
        }

        /// <summary>
        /// Перевод денег между счетами.
        /// </summary>
        static void Ex1()
        {
            BankAccount myFirstBankAccount = new BankAccount();
            myFirstBankAccount.SetAccountData(1000000000, BankAccountType.Savings);
            myFirstBankAccount.PrintAccountInfo();

            BankAccount mySecondBankAccount = new BankAccount();
            mySecondBankAccount.SetAccountData(100, BankAccountType.Savings);
            mySecondBankAccount.PrintAccountInfo();
            mySecondBankAccount.TransferMoneyTo(myFirstBankAccount, 100);
            mySecondBankAccount.PrintAccountInfo();
            myFirstBankAccount.PrintAccountInfo();

        }
        /// <summary>
        /// Переворот строки.
        /// </summary>
        static void Ex2()
        {
            string line = "hello";
            Console.WriteLine($"Обратная сторка: {line}");
            Console.WriteLine($"Перевернутая сторка: {StringReverse(line)}");
        }

        /// <summary>
        /// Метод для переворота строки.
        /// </summary>
        /// <param name="line">Исходная строка.</param>
        /// <returns>Перевернутая строка.</returns>
        static string StringReverse(string line)
        {
            char[] charArray = line.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Работа с файлами.
        /// </summary>
        static void Ex3()
        {
            Console.Write("Введи название файла(в папке txts): ");
            string fileName = $"../../../txts/{Console.ReadLine()}";
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                File.WriteAllText("../../../txts/result.txt", File.ReadAllText(fileName).ToUpper());
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
        }
        static bool CheckIfFormattable(object input)
        {
            if (input is IFormattable)
            {
                Console.WriteLine($"{input} реализует IFormattable (проверяется с помощью 'is').");
                return true;
            }

            var formattable = input as IFormattable;
            if (formattable != null)
            {
                Console.WriteLine($"{input} реализует IFormattable (проверяется с помощью 'as').");
                return true;
            }

            Console.WriteLine($"{input} не реализует IFormattable.");
            return false;
        }
        static void Ex4()
        {
            object obj1 = 123;
            object obj2 = "Hello world";
            object obj3 = 123.45m;

            Console.WriteLine(CheckIfFormattable(obj1));
            Console.WriteLine(CheckIfFormattable(obj2));
            Console.WriteLine(CheckIfFormattable(obj3));
        }


        static void Ex5()
        {
            string[] allLines = File.ReadAllLines("../../../txts/workers.txt");
            for (int i = 0; i < allLines.Length; i++)
            {
                SearchMail(ref allLines[i]);
            }
            File.WriteAllLines("../../../txts/emails.txt", allLines);
        }
        public static void SearchMail(ref string s)
        {
            s = s.Split("#")[1].Replace(" ", "");
        }
        static void Ex6()
        {
            Song song1 = new Song();
            song1.SetName("Song A");
            song1.SetAuthor("Author A");

            Song song2 = new Song();
            song2.SetName("Song B");
            song2.SetAuthor("Author B");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("Song C");
            song3.SetAuthor("Author C");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Song D");
            song4.SetAuthor("Author D");
            song4.SetPrev(song3);

            Song[] songs = { song1, song2, song3, song4 };
            Console.WriteLine("Список песен:");
            foreach (Song song in songs)
            {
                song.PrintInfo();
                Console.WriteLine();
            }

            Console.Write("Сравнение первой и второй песни: ");
            if (song1.Equals(song2))
            {
                Console.WriteLine("Первая и вторая песни одинаковы.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }


    }
}

