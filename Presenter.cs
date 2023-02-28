using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace SecondLab
{
    public class Presenter : IPresenter
    {
        public Presenter(IViewLoginForm startForm, IViewMainForm mainForm, Model model)
        {
            this.startForm = startForm;
            this.mainForm = mainForm;
            this.model = model;

            startForm.Login += () => Login(startForm.UserLogin, startForm.Password);
           //model.ShowMainForm += () => StartWindowClose();
            model.ShowMainForm += () => MainWindowRun(model.MenuFile);

        }


        public void StartWindowRun()
        {
            startForm.Show();
        }

        public void StartWindowClose()
        {
            startForm.Close();
        }

        public void MainWindowRun(string menuFile)
        {
            CreateMenu(menuFile);
            mainForm.Show();
        }
        public void CreateMenu(string menuFile)
        {
            mainForm.RenderingMenu(menuFile);
        }

        private void Login(string userLogin, string userPassword)
        {
            try
            {
                model.IsUserExist(userLogin, userPassword);
            }
            catch(Exception mes)
            {
                startForm.ShowError(mes.Message);
            }
        }


        private readonly IViewLoginForm startForm;
        private IViewMainForm mainForm;
        private Model model;
    }
}
