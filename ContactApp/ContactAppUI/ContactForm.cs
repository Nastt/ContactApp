using System;
using System.Drawing;
using System.Windows.Forms;
using ContactApp;

namespace ContactAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Времененное хранение контакта
        /// </summary>
        private Contact _contact = new Contact();

        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = (Contact)value.Clone();
                SurnameBox.Text = value.Surname;
                NameBox.Text = value.Name;
                vkBox.Text = value.IdVk;
                EmailBox.Text = value.Email;
                if (value.PhoneNumber.Number != 0)
                    PhoneBox.Text = value.PhoneNumber.Number.ToString();
                BirthdayTimePicker.Value = value.Birthday;
            }
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            BirthdayTimePicker.MaxDate = DateTime.Now;
            BirthdayTimePicker.Value = BirthdayTimePicker.MaxDate;
        }

        /// <summary>
        /// Создание контакта для добавления или редактирования
        /// </summary>
        private void ModifyContact()
        {
            try
            {
                Contact.Surname = SurnameBox.Text;
                Contact.Name = NameBox.Text;
                Contact.IdVk = vkBox.Text;
                Contact.Email = EmailBox.Text;
                Contact.Birthday = BirthdayTimePicker.Value;
                var phoneNumber = new PhoneNumber
                {
                    Number = PhoneBox.Text != "" ? Convert.ToInt64(PhoneBox.Text) : 0
                };
                Contact.PhoneNumber = phoneNumber;
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ограничения на вводимые символы в поле PhoneBox
        /// </summary>
        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }

            if (PhoneBox.Text.Length == 1)
            {
                if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Ограничения на вводимые символы в поле vkBox
        /// </summary>
        private void vkBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Delete) && (!Char.IsLetter(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (vkBox.Text.Length == 2)
            {
                if (!Char.IsDigit(e.KeyChar) && (!Char.IsLetter(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Изменение текстового поля vkBox при ошибке вводе
        /// </summary>
        private void vkBox_TextChanged(object sender, EventArgs e)
        {
            if (vkBox.Text.Length > 0)
            {
                if (vkBox.Text.Length > 17)
                {
                    vkBox.BackColor = Color.Salmon;
                }
                else
                {
                    vkBox.BackColor = Color.White;
                }
            }
            else
            {
                vkBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Изменение текстового поля SurnameBox при ошибке вводе
        /// </summary>
        private void SurnameBox_TextChanged(object sender, EventArgs e)
        {
            if (SurnameBox.Text.Length > 0)
            {
                if (SurnameBox.Text.Length > 50)
                {
                    SurnameBox.BackColor = Color.Salmon;
                }
                else
                {
                    SurnameBox.BackColor = Color.White;
                }
            }
            else
            {
                SurnameBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Изменение текстового поля NameBox при ошибке вводе
        /// </summary>
        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            if (NameBox.Text.Length > 0)
            {
                if (NameBox.Text.Length > 50)
                {
                    NameBox.BackColor = Color.Salmon;
                }
                else
                {
                    NameBox.BackColor = Color.White;
                }
            }
            else
            {
                NameBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Изменение текстового поля PhoneBox при ошибке вводе
        /// </summary>
        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            if (PhoneBox.Text.Length > 0)
            {
                if ((PhoneBox.Text.Length > 11))
                {
                    PhoneBox.BackColor = Color.Salmon;
                }
                else
                {
                    PhoneBox.BackColor = Color.White;
                }
            }
            else
            {
                PhoneBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Изменение текстового поля EmailBox при ошибке вводе
        /// </summary>
        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            if (EmailBox.Text.Length > 50)
            {
                EmailBox.BackColor = Color.Salmon;
            }
            else
            {
                EmailBox.BackColor = Color.White;
            }
        }

        private void vkBox_MouseDown(object sender, MouseEventArgs e)
        {
            vkBox.SelectionStart = vkBox.Text.Length;
        }

        private void PhoneBox_MouseDown(object sender, MouseEventArgs e)
        {
            PhoneBox.SelectionStart = PhoneBox.Text.Length;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            ModifyContact();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}