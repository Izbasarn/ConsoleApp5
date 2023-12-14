using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddBook.DAL
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }

        public Contact() { }  // Добавьте конструктор по умолчанию

        public Contact(string firstName, string lastName, string number, string email, string address, string fullName)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            Email = email;
            Address = address;
            FullName = firstName + " " + lastName;
        }

        public override string ToString()
        {
            return $"Имя: {FirstName}, Фамилия: {LastName}, Телефон: {Number}, Почта: {Email}, Адрес: {Address}";
        }
    }
}