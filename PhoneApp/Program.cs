// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;


Console.WriteLine("===========PhoneApp===========");
Console.Write("Enter a contact name ");
string? name = Console.ReadLine();
Console.Write("Enter a contact phone number ");
string? number = Console.ReadLine();

Contact contacts = new Contact(name, number);
PhoneBook phoneList = new PhoneBook(contacts);

phoneList.AddContacts(contacts);
phoneList.ViewContact();






public class Contact
{
    public string? Name { get; set; }
    public string? Number { get; set; }

    public Contact(string? name, string? number)
    {
        Name = name;
        Number = number;
    }
}


public class PhoneBook
{
    public List<Contact> _contacts { get; set; } = new List<Contact>();

    public PhoneBook(Contact contact)
    {
        Console.WriteLine("Contact created...");
    }

    public void AddContacts(Contact contact)
    {
        _contacts.Add(contact);
        Console.WriteLine("Contact saved...");
    }

    public void ViewContact()
    {
        foreach(var contact in _contacts)
        {
            Console.WriteLine($"{contact.Name}: {contact.Number}");
        }
    }


}

