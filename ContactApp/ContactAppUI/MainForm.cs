using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactApp;
using System.Linq;
using System.Data;

namespace ContactAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Переменная для хранения всех контактов проекта.
        /// </summary>
        private Project _project;
        private List<Contact> _actualList = new List<Contact>();

        /// <summary>
        /// Переменная для хранения отсортированных контактов проекта.
        /// </summary>
        private List<Contact> _sortList = new List<Contact>();
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
                _actualList.Add(Contact);
                UpdateListBox();
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
                var selectContact = _actualList[selectIndex];
                var updateContact = new ContactForm { Contact = selectContact };
                var dialogResult = updateContact.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var projectEditIndex = _project.Contacts.IndexOf(selectContact);
                    _project.Contacts.RemoveAt(projectEditIndex);
                    _project.Contacts.Insert(projectEditIndex, updateContact.Contact);
                    UpdateListBox();
                    ContactlistBox.SelectedIndex = 0;
                    ContactsBirthdays();
                }

                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
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
                var selectContact = _actualList[selectIndex];
                var dialogResult = MessageBox.Show(
                   $"Do you really want to remove contact?",
                   "Confirmation", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var projectEditIndex = _project.Contacts.IndexOf(selectContact);
                    _project.Contacts.RemoveAt(projectEditIndex);
                    UpdateListBox();
                }
                ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
                if (ContactlistBox.Items.Count > 0)
                {
                    ContactlistBox.SelectedIndex = 0;
                }
                else
                {
                    ListBoxNotEmpty();
                }
                ContactsBirthdays();
            }
        }

        //Отображение данных на правой панели по умолчанию.  
        private void ListBoxNotEmpty()
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
                var selectedContact = _actualList[ContactlistBox.SelectedIndex];
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
                ListBoxNotEmpty();
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
                    if (SortTextBox.Text.Length <= maxLengthElement &&
                        SortTextBox.Text.Length <= _sortList[i].Surname.Length &&
                        Equals(SortTextBox.Text, _sortList[i].Surname.Substring(0, SortTextBox.Text.Length)))
                    {
                        _actualList.Add(_sortList[i]);
                        ContactlistBox.Items.Add(_sortList[i].Surname);
                    }
                }
            }
        }

        /// <summary>
        /// Метод, показывающий контакты, у которых сегодня день рождения
        /// </summary>
        private void ContactsBirthdays()
        {
            var surnames = _project.Contacts.Where(contact =>
                contact.Birthday == DateTime.Today).Select(contact => contact.Surname);
            ContactsBirthdayLabel.Text = string.Join(", ", surnames);
        }

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastSelectedContact();
            ProjectManager.SaveToFile(_project, ProjectManager.PathToFolder, ProjectManager.PathToFile);
        }

        private void SortTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
            if (SortTextBox.Text.Length > 0)
            {
                SortTextBox.Text = char.ToUpper(SortTextBox.Text[0]) + SortTextBox.Text.Substring(1).ToLower();
                if (SortTextBox.Text.Length == 1)
                    SortTextBox.SelectionStart = SortTextBox.Text.Length;
            }
        }

        private void MaxLengthElement()
        {
            for (int i = 0; i < _sortList.Count; i++)
            {
                if (_sortList[i].Surname.Length > maxLengthElement)
                    maxLengthElement = _sortList[i].Surname.Length;
            }
            if (_sortList.Count == 0)
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