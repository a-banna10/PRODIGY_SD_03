using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tsk3
{
    public class ContactManager1
    {
        private List<Contact> contacts;
        public ContactManager1()
        {
            contacts = new List<Contact>();
            ViewContacts();
        }
        public void AddContact(Contact contact)
        { 
            contacts.Add(contact);
            SaveContacts();
        }
        public void EditContact(int index, Contact contact)
        {
            if(index!=-1 && index<contacts.Count)
            {
           
                contacts.RemoveAt(index);
                contacts.Insert(index, contact);
                SaveContacts() ;

            }
        }
        public void DeleteContact(int index) 
        {
            contacts.RemoveAt(index);
            SaveContacts();
        }
        public List<Contact> GetContacts()
        {
            return contacts;
        }

        private void SaveContacts()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("contacts.txt"))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine(contact.Name+"-"+contact.PhoneNumber+"-"+contact.EmailAddress);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error saving contacts: " + ex.Message);
            }
        }

        private void ViewContacts()
        {
            try
            {
                if (File.Exists("contacts.txt"))
                {
                    contacts = new List<Contact>();
                    string[] lines = File.ReadAllLines("contacts.txt");
                    foreach (string line in lines)
                    {
                        string[] arr = line.Split('-');

                        if (arr.Length >= 3) 
                        {
                            Contact contact = new Contact(arr[0], arr[1], arr[2]);
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error loading contacts: " + ex.Message);
            }
        }
    }
}
