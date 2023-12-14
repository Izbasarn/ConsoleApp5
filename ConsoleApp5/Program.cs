using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Contact(string firstName, string lastName, string phoneNumber, string email, string address = "")
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Телефон: {PhoneNumber}, Email: {Email}, Адрес: {Address}";
    }
}

public class AddressBook
{
    private List<Contact> _contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        if (!IsPhoneNumberValid(contact.PhoneNumber))
        {
            Console.WriteLine("Некорректный формат номера телефона.");
            return;
        }

        if (_contacts.Any(c => c.PhoneNumber == contact.PhoneNumber))
        {
            Console.WriteLine("Контакт с таким номером телефона уже существует.");
            return;
        }
        _contacts.Add(contact);
        Console.WriteLine("Контакт успешно добавлен!");
    }

    public void DeleteContact(string identifier)
    {
        var contact = _contacts.FirstOrDefault(c => c.FirstName == identifier || c.PhoneNumber == identifier);
        if (contact != null)
        {
            _contacts.Remove(contact);
            Console.WriteLine("Контакт успешно удален!");
        }
        else
        {
            Console.WriteLine("Контакт не найден.");
        }
    }

    public void EditContact(string phoneNumber, string firstName, string lastName, string email, string address)
    {
        var contact = _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        if (contact != null)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Email = email;
            contact.Address = address;
            Console.WriteLine("Контакт успешно отредактирован!");
        }
        else
        {
            Console.WriteLine("Контакт не найден.");
        }
    }

    public void FindContact(string identifier)
    {
        var contact = _contacts.FirstOrDefault(c => c.FirstName == identifier || c.PhoneNumber == identifier);
        if (contact != null)
        {
            Console.WriteLine(contact);
        }
        else
        {
            Console.WriteLine("Контакт не найден.");
        }
    }

    public void DisplayContacts()
    {
        foreach (var contact in _contacts.OrderBy(c => c.FirstName))
        {
            Console.WriteLine(contact);
        }
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
        // Простая проверка на корректный формат номера телефона (10 цифр)
        return Regex.IsMatch(phoneNumber, @"^\d{10}$");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("\n1. Добавить контакт\n2. Удалить контакт\n3. Редактировать контакт\n4. Найти контакт\n5. Показать все контакты\n6. Выход");
            Console.Write("Выберите действие: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact(addressBook);
                    break;
                case "2":
                    DeleteContact(addressBook);
                    break;
                case "3":
                    EditContact(addressBook);
                    break;
                case "4":
                    FindContact(addressBook);
                    break;
                case "5":
                    addressBook.DisplayContacts();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Пожалуйста, выберите действие от 1 до 6.");
                    break;
            }
        }
    }

    static void AddContact(AddressBook addressBook)
    {
        Console.Write("Введите имя: ");
        var firstName = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        var lastName = Console.ReadLine();
        Console.Write("Введите номер телефона: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Введите email: ");
        var email = Console.ReadLine();
        Console.Write("Введите адрес (необязательно): ");
        var address = Console.ReadLine();

        var newContact = new Contact(firstName, lastName, phoneNumber, email, address);
        addressBook.AddContact(newContact);
    }

    static void DeleteContact(AddressBook addressBook)
    {
        Console.Write("Введите имя или номер телефона для удаления: ");
        var identifier = Console.ReadLine();
        addressBook.DeleteContact(identifier);
    }

    static void EditContact(AddressBook addressBook)
    {
        Console.Write("Введите номер телефона для редактирования: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Введите новое имя: ");
        var firstName = Console.ReadLine();
        Console.Write("Введите новую фамилию: ");
        var lastName = Console.ReadLine();
        Console.Write("Введите новый email: ");
        var email = Console.ReadLine();
        Console.Write("Введите новый адрес (необязательно): ");
        var address = Console.ReadLine();

        addressBook.EditContact(phoneNumber, firstName, lastName, email, address);
    }

    static void FindContact(AddressBook addressBook)
    {
        Console.Write("Введите имя или номер телефона для поиска: ");
        var identifier = Console.ReadLine();
        addressBook.FindContact(identifier);
    }
}
