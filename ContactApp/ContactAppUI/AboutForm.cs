using System.Windows.Forms;

namespace ContactAppUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject(emailLabel.Text);
        }

        private void gitHubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Nastt/ContactApp.git");
        }
    }
}
