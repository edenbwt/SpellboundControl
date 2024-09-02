using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpellboundControl.Forms
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        //Num_Contact label to update wis contact number
        //Phone_ID same sing update phone target id


        public void SetContacts(List<Contact> contacts)
        {
            dataGridViewContacts.Rows.Clear();
            foreach (var contact in contacts)
            {
                dataGridViewContacts.Rows.Add(contact.Id, contact.Name, contact.Number, contact.Email);
            }


            Num_Contact.Text = contacts.Count.ToString();
        }


    }
}
