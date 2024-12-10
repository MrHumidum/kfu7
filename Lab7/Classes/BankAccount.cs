using System;

namespace Lab7;
/// <summary>
/// Перечисление, представляющее виды банковских счетов.
/// </summary>
enum BankAccountType
{
    /// <summary>
    /// Текущий счет.
    /// </summary>
    Current,

    /// <summary>
    /// Сберегательный счет.
    /// </summary>
    Savings
}

/// <summary>
/// Класс, представляющий банковский счет.
/// </summary>
class BankAccount
{

    /// <summary>
    /// Номер счета.
    /// </summary>
    private int accountNumber;

    /// <summary>
    /// Статическая переменная для генерации уникальных номеров счетов.
    /// </summary>
    private static int nextAccountNumber = 0;

    /// <summary>
    /// Баланс счета.
    /// </summary>
    private decimal balance;

    /// <summary>
    /// Тип банковского счета.
    /// </summary>
    private BankAccountType accountType;

    // Конструктор к заданию 7.1
    // public BankAccount(int number, decimal balance, BankAccountType type)
    // {
    //     this.accountNumber = number;
    //     this.balance = balance;
    //     this.accountType = type;
    // }

    /// <summary>
    /// Конструктор, создающий банковский счет с заданным балансом и типом.
    /// </summary>
    /// <param name="balance">Начальный баланс счета.</param>
    /// <param name="type">Тип банковского счета.</param>
    public BankAccount(decimal balance, BankAccountType type)
    {
        this.accountNumber = AccountNumberGenerator();
        this.balance = balance;
        this.accountType = type;
    }

    /// <summary>
    /// Конструктор по умолчанию, создающий счет с нулевым балансом.
    /// </summary>
    public BankAccount()
    {
        this.accountNumber = AccountNumberGenerator();

    }
    // Метод для установки данных банковского счета к заданию 7.1
    // /// <summary>
    // /// Метод для установки данных банковского счета.
    // /// </summary>
    // /// <param name="number">Номер счета.</param>
    // /// <param name="balance">Баланс счета.</param>
    // /// <param name="type">Тип банковского счета.</param>
    // public void SetAccountData(int number, decimal balance, BankAccountType type)
    // {
    //     this.accountNumber = number;
    //     this.balance = balance;
    //     this.accountType = type;
    // }


    /// <summary>
    /// Метод для вывода информации о банковском счете.
    /// </summary>
    public void PrintAccountInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance:C}\nТип банковского счета: {accountType}");
    }

    /// <summary>
    /// Генерирует уникальный номер счета.
    /// </summary>
    /// <returns>Уникальный номер счета.</returns>
    private int AccountNumberGenerator()
    {
        return nextAccountNumber++;
    }


    /// <summary>
    /// Устанавливает данные банковского счета.
    /// </summary>
    /// <param name="balance">Начальный баланс счета.</param>
    /// <param name="type">Тип банковского счета.</param>
    public void SetAccountData(decimal balance, BankAccountType type)
    {
        this.accountNumber = AccountNumberGenerator();
        this.balance = balance;
        this.accountType = type;
    }

    /// <summary>
    /// Снимает указанную сумму с баланса счета, если средств достаточно.
    /// </summary>
    /// <param name="money">Сумма для снятия с счета.</param>
    public void WithdrawMoney(decimal money)
    {
        if ((this.balance - money) >= 0)
        {
            this.balance -= money;
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счету");
        }
    }

    /// <summary>
    /// Вносит указанную сумму на баланс счета.
    /// </summary>
    /// <param name="money">Сумма для депозита на счет.</param>
    public void DepositMoney(decimal money)
    {
        this.balance += money;
    }

    /// <summary>
    /// Переводит деньги на другой банковский счет.
    /// </summary>
    /// <param name="bankAccount">Счет, на который переводятся деньги.</param>
    /// <param name="money">Сумма перевода.</param>
    public void TransferMoneyTo(BankAccount bankAccount, decimal money)
    {
        if ((this.balance - money) >= 0)
        {
            this.balance -= money;
            bankAccount.balance += money;
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счету");
        }
    }

}



