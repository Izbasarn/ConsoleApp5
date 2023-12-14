using AddBook.DAL;
using AddBook.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBook.BLL
{
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();
        private const string fileName = "contacts.txt";
        private readonly IOutputProvider outputProvider;

        public ContactManager(IOutputProvider outputProvider)
        {
            this.outputProvider = outputProvider;
        }

        public void AddContact()
        {
            Contact contact = new Contact();
            outputProvider.WriteLine("Введите имя: ");
            contact.FirstName = Console.ReadLine();
            outputProvider.WriteLine("Введите фамилию: ");
            contact.LastName = Console.ReadLine();
            outputProvider.WriteLine("Введите номер телефона: ");
            contact.Number = Console.ReadLine();
            outputProvider.WriteLine("Введите электронную почту: ");
            contact.Email = Console.ReadLine();
            outputProvider.WriteLine("Введите адрес: ");
            contact.Address = Console.ReadLine();

            contacts.Add(contact);
            outputProvider.WriteLine("Контакт успешно добавлен!");
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                outputProvider.WriteLine("Список контактов пуст.");
            }
            else
            {
                outputProvider.WriteLine("Список контактов:");
                foreach (var contact in contacts)
                {
                    outputProvider.WriteLine(contact.ToString());
                }
            }
        }

        public void DeleteContact()
        {
            outputProvider.WriteLine("Введите имя или номер телефона контакта для удаления: ");
            string searchQuery = Console.ReadLine();

            Contact contactToDelete = contacts.Find(c => c.FirstName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                        c.Number.Equals(searchQuery));

            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                outputProvider.WriteLine("Контакт успешно удален!");
            }
            else
            {
                outputProvider.WriteLine("Контакт не найден.");
            }
        }

        public void EditContact()
        {
            outputProvider.WriteLine("Введите имя или номер телефона контакта для редактирования: ");
            string searchQuery = Console.ReadLine();

            Contact contactToEdit = contacts.Find(c => c.FirstName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                                      c.Number.Equals(searchQuery));

            if (contactToEdit != null)
            {
                outputProvider.WriteLine($"Редактирование контакта: {contactToEdit}");
                outputProvider.WriteLine("Введите новое имя: ");
                contactToEdit.FirstName = Console.ReadLine();
                outputProvider.WriteLine("Введите новую фамилию: ");
                contactToEdit.LastName = Console.ReadLine();
                outputProvider.WriteLine("Введите новый номер телефона: ");
                contactToEdit.Number = Console.ReadLine();
                outputProvider.WriteLine("Введите новую электронную почту: ");
                contactToEdit.Email = Console.ReadLine();
                outputProvider.WriteLine("Введите новый адрес: ");
                contactToEdit.Address = Console.ReadLine();

                outputProvider.WriteLine("Контакт успешно отредактирован!");
            }
            else
            {
                outputProvider.WriteLine("Контакт не найден.");
            }
        }

        public void SearchContact()
        {
            outputProvider.WriteLine("Введите имя или номер телефона для поиска контакта: ");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = contacts
                .Where(c => c.FirstName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                            c.Number.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (searchResults.Count > 0)
            {
                outputProvider.WriteLine("Результаты поиска:");
                foreach (var result in searchResults)
                {
                    outputProvider.WriteLine(result.ToString());
                }
            }
            else
            {
                outputProvider.WriteLine("Контакт не найден.");
            }
        }


        public void DisplayContactsAlphabetically()
        {
            List<Contact> sortedContacts = contacts.OrderBy(c => c.FirstName).ToList();

            if (sortedContacts.Count == 0)
            {
                outputProvider.WriteLine("Список контактов пуст.");
            }
            else
            {
                outputProvider.WriteLine("Список контактов в алфавитном порядке:");
                foreach (var contact in sortedContacts)
                {
                    outputProvider.WriteLine(contact.ToString());
                }
            }
        }

        public void LoadContacts()
        {
            if (File.Exists(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    foreach (var line in lines)
                    {
                        string[] parts = line.Split(',');
                        Contact contact = new Contact
                        {
                            FirstName = parts[0],
                            LastName = parts[1],
                            Number = parts[2],
                            Email = parts[3],
                            Address = parts[4]
                        };
                        contacts.Add(contact);
                    }

                    outputProvider.WriteLine("Контакты успешно загружены из файла.");
                }
                catch (Exception ex)
                {
                    outputProvider.WriteLine($"Ошибка при загрузке контактов: {ex.Message}");
                }
            }
        }

        public void SaveContacts()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"{contact.FirstName},{contact.LastName},{contact.Number},{contact.Email},{contact.Address}");
                    }
                }

                outputProvider.WriteLine("Контакты успешно сохранены в файл.");
            }
            catch (Exception ex)
            {
                outputProvider.WriteLine($"Ошибка при сохранении контактов: {ex.Message}");
            }
        }
    }
}
