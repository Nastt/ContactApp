using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhoneNumber phoneNumber = new PhoneNumber
            {
                Number = Convert.ToInt64(79528057827)
            };

            Contact Contact = new Contact
            {
                Name = "Анастасия",
                Surname = "Маркина",
                IdVk = "_1234",
                Email = "1234@mail.ru",
                Birthday = new DateTime(1999, 2, 20),
                PhoneNumber = phoneNumber,
            };

            Project serelProject = new Project { Contacts = { Contact } };
            ProjectManager.SaveToFile(serelProject, ProjectManager.PathToFolder);

            Project deserProject = ProjectManager.LoadFromFile(ProjectManager.PathToFolder);

            MessageBox.Show("Контакт сохранен");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyContactForm form = new ModifyContactForm();
            form.Show();
        }
    }
}
