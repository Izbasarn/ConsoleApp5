using AddBook.BLL;
using AddBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOutputProvider outputProvider = new ConsoleOutputProvider();
            ContactManager contactManager = new ContactManager(outputProvider);
            contactManager.LoadContacts();

            while (true)
            {
                outputProvider.WriteLine("Простой менеджер контактов");
                outputProvider.WriteLine("1. Добавить контакт");
                outputProvider.WriteLine("2. Просмотреть все контакты");
                outputProvider.WriteLine("3. Удалить контакт");
                outputProvider.WriteLine("4. Редактировать контакт");
                outputProvider.WriteLine("5. Поиск контакта");
                outputProvider.WriteLine("6. Вывести все контакты в алфавитном порядке");
                outputProvider.WriteLine("7. Выход из программы");
                outputProvider.WriteLine("Выберите действие (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        contactManager.AddContact();
                        break;
                    case "2":
                        contactManager.DisplayContacts();
                        break;
                    case "3":
                        contactManager.DeleteContact();
                        break;
                    case "4":
                        contactManager.EditContact();
                        break;
                    case "5":
                        contactManager.SearchContact();
                        break;
                    case "6":
                        contactManager.DisplayContactsAlphabetically();
                        break;
                    case "7":
                        contactManager.SaveContacts();
                        return;
                    default:
                        outputProvider.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }

               Console.WriteLine("Некоректный выбор. Попробуйте снова");
            }
        }
    }
}
