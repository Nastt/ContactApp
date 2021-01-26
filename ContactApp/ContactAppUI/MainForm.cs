using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactApp;

namespace ContactAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Переменная для хранения всех контактов проекта.
        /// </summary>
        private Project _project;

        /// <summary>
        /// Контакты, отображаемые в текущее время на ListBox.
        /// </summary>
        private List<Contact> _displayedContacts = new List<Contact>();
        private int maxLengthElement = 0;

        public MainForm()
        {
            InitializeComponent();
            BirthdayTimePicker.Value = DateTime.Now;
            _project = ProjectManager.LoadFromFile(ProjectManager.PathToFile);
            foreach (var contact in _project.Contacts)
            {
                ContactlistBox.Items.Add(contact.Surname);
            }
            ContactsBirthdays();
            UpdateListBox();
            SortListBox();
            if (_project.SelectedIndex > 0)
                ContactlistBox.SelectedIndex = _project.SelectedIndex;
            else
            {
                if (_project.Contacts.Count > 0)
                    ContactlistBox.SelectedIndex = 0;
            }
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
                _displayedContacts.Add(Contact);
                UpdateListBox();
                SortListBox();
                ContactlistBox.SelectedIndex = 0;
                ContactsBirthdays();
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
                var selectIndex = ContactlistBox.SelectedIndex;
                var selectContact = _displayedContacts[selectIndex];
                var updateContact = new ContactForm { Contact = selectContact };
                var dialogResult = updateContact.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var projectEditIndex = _project.Contacts.IndexOf(selectContact);
                    _project.Contacts.RemoveAt(projectEditIndex);
                    _project.Contacts.Insert(projectEditIndex, updateContact.Contact);
                    UpdateListBox();
                    SortListBox();                   
                }
                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
                ContactsBirthdays();
                if (_displayedContacts.Count == 0)
                {
                    SortTextBox.Text = updateContact.Contact.Surname;
                }
                else
                {
                    ContactlistBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void RemoveContact()
        {
            if (ContactlistBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select contact to delete", "Contact not selected");
            }
            else
            {
                var selectIndex = ContactlistBox.SelectedIndex;
                var selectContact = _displayedContacts[selectIndex];
                var dialogResult = MessageBox.Show(
                   $"Do you really want to remove contact?",
                   "Confirmation", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var projectEditIndex = _project.Contacts.IndexOf(selectContact);
                    _project.Contacts.RemoveAt(projectEditIndex);
                    UpdateListBox();
                    SortListBox();
                }
                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);

                if (ContactlistBox.Items.Count > 0)
                {
                    ContactlistBox.SelectedIndex = 0;
                }
                else
                {
                    ListBoxCountNull();
                }
                ContactsBirthdays();
            }
        }

        //Отображение данных на правой панели по умолчанию.  
        private void ListBoxCountNull()
        {
            SurnameBox.Text = "";
            NameBox.Text = "";
            PhoneMaskBox.Text = "";
            EmailBox.Text = "";
            vkBox.Text = "";
            BirthdayTimePicker.Value = DateTime.Now;
        }

        private void ContactlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactlistBox.SelectedIndex >= 0)
            {
                var selectedContact = _displayedContacts[ContactlistBox.SelectedIndex];
                SurnameBox.Text = selectedContact.Surname;
                NameBox.Text = selectedContact.Name;
                PhoneMaskBox.Text = selectedContact.PhoneNumber.Number.ToString();
                EmailBox.Text = selectedContact.Email;
                vkBox.Text = selectedContact.IdVk;
                BirthdayTimePicker.Value = selectedContact.Birthday;
                LastSelectedContact();
            }
            else
            {
                ListBoxCountNull();
            }
        }

        /// <summary>
        /// Метод, сортирующий контакты по алфавиту
        /// </summary>
        private void SortListBox()
        {
            _displayedContacts = _project.SortContacts(_displayedContacts);

            ContactlistBox.Items.Clear();

            foreach (var contact in _displayedContacts)
            {
                ContactlistBox.Items.Add(contact.Surname);
            }
        }

        /// <summary>
        /// Метод, показывающий контакты, у которых сегодня день рождения
        /// </summary>
        private void ContactsBirthdays()
        {
            ContactsBirthdayLabel.Text = "";
            var _sortContacts = _project.SortContacts(_project.Contacts);
            for (int i = 0; i < _sortContacts.Count; i++)
            {
                if (_sortContacts[i].Birthday.Day == DateTime.Today.Day &&
                   _sortContacts[i].Birthday.Month == DateTime.Today.Month)
                    ContactsBirthdayLabel.Text += _sortContacts[i].Surname + " ";
            }
            if (ContactsBirthdayLabel.Text == "")
            {
                ContactsBirthdayLabel.Text = "No one";
            }

        }

        private void UpdateListBox()
        {
            MaxLengthElement();
            if (SortTextBox.Text.Length == 0)
            {
                _displayedContacts.Clear();
                _displayedContacts = _project.Contacts;
            }
            else
            {
                _displayedContacts.Clear();
                for (int i = 0; i < _project.Contacts.Count; i++)
                {
                    if (SortTextBox.Text.Length <= maxLengthElement &&
                        SortTextBox.Text.Length <= _project.Contacts[i].Surname.Length &&
                        Equals(SortTextBox.Text, _project.Contacts[i].Surname.Substring(0, SortTextBox.Text.Length)))
                    {
                        _displayedContacts.Add(_project.Contacts[i]);
                    }
                }
            }
        }

        private void LastSelectedContact()
        {
            var _sortContacts = _project.SortContacts(_project.Contacts);
            if (ContactlistBox.SelectedIndex >= 0)
            {
                _project.SelectedIndex = _sortContacts.IndexOf(_displayedContacts[ContactlistBox.SelectedIndex]);
            }
            else
            {
                _project.SelectedIndex = -1;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastSelectedContact();
            ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
        }

        private void SortTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
            SortListBox();
            if (SortTextBox.Text.Length > 0)
            {
                SortTextBox.Text = char.ToUpper(SortTextBox.Text[0]) + SortTextBox.Text.Substring(1).ToLower();
                if (SortTextBox.Text.Length == 1)
                    SortTextBox.SelectionStart = SortTextBox.Text.Length;
            }
        }

        private void MaxLengthElement()
        {
            for (int i = 0; i < _project.Contacts.Count; i++)
            {
                if (_project.Contacts[i].Surname.Length > maxLengthElement)
                    maxLengthElement = _project.Contacts[i].Surname.Length;
            }
            if (_project.Contacts.Count == 0)
                maxLengthElement = 0;
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
    }
}