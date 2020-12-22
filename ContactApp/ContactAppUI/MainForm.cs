using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactApp;

namespace ContactAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;
        public MainForm()
        {
            InitializeComponent();

            _project = ProjectManager.LoadFromFile(ProjectManager.PathToFolder);

            foreach (var contact in _project.Contacts)
            {
                ContactlistBox.Items.Add(contact.Surname);
            }
        }

        private void ContactlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _project.Contacts[selectedIndex];
                SurnameBox.Text = contact.Surname;
                NameBox.Text = contact.Name;
                BirthdayTimePicker.Value = contact.Birthday;
                PhoneMaskBox.Text = contact.PhoneNumber.Number.ToString();
                EmailBox.Text = contact.Email;
                vkBox.Text = contact.IdVk;
            }
            else
            {
                SurnameBox.Text = "";
                NameBox.Text = "";
                BirthdayTimePicker.Value = DateTime.Today;
                PhoneMaskBox.Text = "";
                EmailBox.Text = "";
                vkBox.Text = "";
            }
        }

        /// <summary>
        /// Метод добавления контакта
        /// </summary>
        private void AddContact()
        {
            var form = new ModifyContactForm();
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var Contact = form.Contact;
                _project.Contacts.Add(Contact);
                ContactlistBox.Items.Add(Contact.Surname);
                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder);
                ContactlistBox.SetSelected(ContactlistBox.Items.IndexOf(Contact.Surname), true);
            }

        } 
        
        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        private void EditContact()
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select contact to edit", "Contact not selected");
            }
            else
            {
                var selectedContact = _project.Contacts[selectedIndex];
                var form = new ModifyContactForm();
                form.Contact = selectedContact;
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    var updatedContact = form.Contact;
                    _project.Contacts.RemoveAt(selectedIndex);
                    ContactlistBox.Items.RemoveAt(selectedIndex);
                    _project.Contacts.Insert(selectedIndex, updatedContact);
                    ContactlistBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder);
                }
                ContactlistBox.SetSelected(selectedIndex, true);
            }
        }
        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void RemoveContact()
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select contact to delete", "Contact not selected");
            }
            else
            {
                Contact contact = _project.Contacts[selectedIndex];
                SurnameBox.Text = contact.Surname;
                var dialogResult = MessageBox.Show("Do you really want to remove contact " + contact.Surname + "?", "Confirmation", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    _project.Contacts.RemoveAt(selectedIndex);
                    ContactlistBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
