using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactApp;

namespace ContactAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;
        /// Переменная для хранения всех названий заметок проекта.
        /// </summary>
        private List<Contact> _actualList = new List<Contact>();
        /// <summary>
        /// Переменная для хранения отсортированных названий заметок проекта.
        /// </summary>
        private List<Contact> _sortList = new List<Contact>();

        private int maxLengthElement = 0;
        public MainForm()
        {
            InitializeComponent();

            _project = ProjectManager.LoadFromFile(ProjectManager.PathToFile);

            foreach (var contact in _project.Contacts)
            {
                ContactlistBox.Items.Add(contact.Surname);
            }

            UpdateListBox();

            if (_project.SelectedIndex > 0)
                ContactlistBox.SelectedIndex = _project.SelectedIndex;
            else
            {
                if (_project.Contacts.Count > 0)
                    ContactlistBox.SelectedIndex = 0;
            }
        }

        private void ContactlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _project.Contacts[selectedIndex];
                UpdateContact(contact);
            }
            else
            {
                ClearContact();
            }
        }

        private void UpdateContact(Contact contact) 
        {
            SurnameBox.Text = contact.Surname;
            NameBox.Text = contact.Name;
            BirthdayTimePicker.Value = contact.Birthday;
            PhoneMaskBox.Text = contact.PhoneNumber.Number.ToString();
            EmailBox.Text = contact.Email;
            vkBox.Text = contact.IdVk;
        }

        private void ClearContact() 
        {
            SurnameBox.Text = "";
            NameBox.Text = "";
            BirthdayTimePicker.Value = DateTime.Now;
            PhoneMaskBox.Text = "";
            EmailBox.Text = "";
            vkBox.Text = "";
        }

        /// <summary>
        /// Метод добавления контакта
        /// </summary>
        private void AddContact()
        {
            var form = new ContactForm();
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var Contact = form.Contact;
                _project.Contacts.Add(Contact);
                ContactlistBox.Items.Add(Contact.Surname);
                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
                ContactlistBox.SetSelected(ContactlistBox.Items.Count - 1, true);
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
                var form = new ContactForm();
                form.Contact = selectedContact;
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var updatedContact = form.Contact;
                    _project.Contacts.RemoveAt(selectedIndex);
                    ContactlistBox.Items.RemoveAt(selectedIndex);
                    _project.Contacts.Insert(selectedIndex, updatedContact);
                    ContactlistBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
                }
                ContactlistBox.SetSelected(selectedIndex, true);
            }
        }

        private void UpdateListBox()
        {
            //Все отсортированные контакты проекта
            _sortList = _project.SortContacts(_project.Contacts);
            MaxLengthElement();

            if (SortTextBox.Text.Length == 0)
            {
                 ContactlistBox.Items.Clear();
                _actualList.Clear();
                for (int i = 0; i < _sortList.Count; i++)
                {
                    _actualList.Add(_sortList[i]);
                    ContactlistBox.Items.Add(_sortList[i].Surname);
                }
            }
            else
            {
                 ContactlistBox.Items.Clear();
                _actualList.Clear();
                for (int i = 0; i < _sortList.Count; i++)
                {                                  
                        if ((String.Equals(SortTextBox.Text, _sortList[i].Surname.ToString().Substring(0, SortTextBox.Text.Length))) && SortTextBox.Text.Length <= maxLengthElement)
                        {
                            _actualList.Add(_sortList[i]);
                            ContactlistBox.Items.Add(_sortList[i].Surname);
                        }                                  
                }
            }
        }

        /// <summary>
        /// Фиксирование выбранной заметки относительно текущей выбранной категории.
        /// </summary>
        private void LastSelectedContact()
        {
            _sortList = _project.SortContacts(_project.Contacts);

            if (ContactlistBox.SelectedIndex >= 0)
            {
                _project.SelectedIndex = _sortList.IndexOf(_actualList[ContactlistBox.SelectedIndex]);
            }
            else
            {
                _project.SelectedIndex = -1;
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
                var dialogResult = MessageBox.Show(
                    $"Do you really want to remove contact {contact.Surname}?", 
                    "Confirmation", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    _project.Contacts.RemoveAt(selectedIndex);
                    ContactlistBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastSelectedContact();
        }

       private void SortTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
            /*if (SortTextBox.Text.Length != 0)
            {
                SortTextBox.Text[0] = char.ToUpper(SortTextBox.Text[0]).ToString();
            }*/
        }

        private void MaxLengthElement()
        {
            for (int i=0; i<_sortList.Count; i++)
            {
                if (_sortList[i].Surname.Length > maxLengthElement)
                    maxLengthElement = _sortList[i].Surname.Length;               
            }
            if (_sortList.Count == 0)
                maxLengthElement = 0;
        }

    }
}

