using System;
using System.Collections.Generic;
using System.Linq;

namespace HW._14._3._3
{
    class Program
    {

        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();


            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();


                if (!Char.IsDigit(keyChar))
                    Console.WriteLine("Ошибка ввода, введите число");
                else
                {
                    IEnumerable<Contact> page = null;

                    switch (keyChar)
                    {
                        case ('1'):
                            page = phoneBook.Take(2);
                            break;
                        case ('2'):
                            page = phoneBook.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = phoneBook.Skip(4).Take(2);
                            break;
                    }

                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы с номером {keyChar} не существует");
                        continue;
                    }

                    var sortedPage = page.OrderBy(s => s.Name).ThenBy(s => s.LastName);

                    Console.WriteLine($"Страница № {keyChar}");
                    Console.WriteLine();
                    foreach (var contact in sortedPage)
                        Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);

                }
            }
        }

    }
    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }


}