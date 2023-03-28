using SecondLab.contracts.Model_contracts;
using System;

namespace SecondLab
{
    public class Presenter : IPresenter
    {
        public Presenter(IViewLoginForm startForm,/* IViewMainForm mainForm,*/ IUserChecker userChecker)
        {
            this.startForm = startForm;
           // this.mainForm = mainForm;
            this.userChecker = userChecker;

            startForm.Login += () => Login(startForm.UserLogin, startForm.Password);
           //model.ShowMainForm += () => StartWindowClose();
            userChecker.ShowMainForm += () => MainWindowRun(userChecker.MenuFile);

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
                userChecker.IsUserExist(userLogin, userPassword);
            }
            catch(Exception mes)
            {
                startForm.ShowError(mes.Message);
                startForm.Close();
            }
        }


        private readonly IViewLoginForm startForm;
        private MainForm mainForm = new MainForm();
        private IUserChecker userChecker;
    }
}
