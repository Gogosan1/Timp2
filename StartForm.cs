using System;
using System.Windows.Forms;

namespace SecondLab
{
    public partial class StartForm : Form, IViewLoginForm
    {
        public StartForm()
        {
            InitializeComponent();
        }


        public new void Show()
        {
            //this.ShowDialog();
           Application.Run(this);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message);
            userLogin.Text = "";
            userPassword.Text = "";
        }

        private void EntranceButton_Click(object sender, EventArgs e)
        {
            Login.Invoke();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

        }
        private new void Close()
        {
            this.Close();
        }

        public string UserLogin { get { return userLogin.Text; } }
        public string Password { get { return userPassword.Text; } }
        public event Action Login;
    }
}
