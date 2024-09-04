using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tsk3
{
    public partial class ContactManager : Form
    {
        private ContactManager1 contactManager;
        public ContactManager()
        {
            InitializeComponent();
            contactManager=new ContactManager1();
            UpdateList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name=txtName.Text;
            string phoneNumber=txtPhoneNumber.Text;
            string emailAddress=txtEmailAddress.Text;

            if (name.Length > 0 && phoneNumber.Length > 0 && emailAddress.Length>0)
            {
                Contact contact = new Contact(name, phoneNumber, emailAddress);
                contactManager.AddContact(contact);
                UpdateList();
                txtName.Clear();
                txtPhoneNumber.Clear();
                txtEmailAddress.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void UpdateList()
        {
            lstContacts.Items.Clear();
            foreach (Contact contact in contactManager.GetContacts())
            {
                lstContacts.Items.Add(contact.Name);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lstContacts.SelectedIndex!=-1)
            {
                string name = txtName.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string emailAddress = txtEmailAddress.Text;
                contactManager.DeleteContact(lstContacts.SelectedIndex);
                if (name.Length > 0 && phoneNumber.Length > 0 && emailAddress.Length > 0)
                {
                    Contact contact = new Contact(name, phoneNumber, emailAddress);
                    contactManager.AddContact(contact);
                    UpdateList();
                    txtName.Clear();
                    txtPhoneNumber.Clear();
                    txtEmailAddress.Clear();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }
            }
            else
            {
                MessageBox.Show("Please select a contact to edit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex != -1)
            {
                contactManager.DeleteContact(lstContacts.SelectedIndex);
                UpdateList();
                txtName.Clear();
                txtPhoneNumber.Clear();
                txtEmailAddress.Clear();
            }
            else
            {
                MessageBox.Show("Please select a contact to delete");
            }
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex != -1)
            {
                Contact contact = contactManager.GetContacts()[lstContacts.SelectedIndex];
                txtName.Text = contact.Name;
                txtPhoneNumber.Text = contact.PhoneNumber;
                txtEmailAddress.Text = contact.EmailAddress;
            }
        }
    }
}
