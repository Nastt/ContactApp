using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactAppUI
{
    public partial class ModifyContactForm : Form
    {
        public ModifyContactForm()
        {
            InitializeComponent();
        }

        private void SurnameBox_TextChanged(object sender, EventArgs e)
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

        private void NameBox_TextChanged(object sender, EventArgs e)
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


        private void PhoneBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (PhoneBox.Text.Length < 0)
            {
                PhoneBox.Text = "Пример ввода: 79528074565";
                PhoneBox.BackColor = Color.Silver;
            }
            else
            {
                PhoneBox.Text = "";
                PhoneBox.BackColor = Color.White;
            }
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            if (PhoneBox.Text.Length > 0)
            {
                if ((PhoneBox.Text[0] != '7'))
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

        private void vkBox_TextChanged(object sender, EventArgs e)
        {
            if (vkBox.Text.Length > 15)
            {
                vkBox.BackColor = Color.Salmon;
            }
            else
            {
                vkBox.BackColor = Color.White;
            }
        }
    }
}
