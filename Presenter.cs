using MenuRendering;
using SecondLab.contracts.Model_contracts;
using System;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace SecondLab
{
    public class Presenter
    {
        public Presenter(IViewLoginForm startForm, IUserChecker userChecker)
        {
            this.startForm = startForm;
            this.userChecker = userChecker;

            startForm.Login += () => Login(startForm.UserLogin, startForm.Password);
            userChecker.ShowMainForm += () => MainWindowRun();
        }

        private void Render_ClickMenuItem(string methodName)
        {
            try
            {
                MethodInfo callStringMethod = GetType().GetMethod(methodName);
                callStringMethod.Invoke(this, null);
            }
            catch(Exception mes) 
            {
                MethodDoesNotExitst(mes.Message + "\nВызван метод по умолчанию." + 
                    $"\nРеализуйте свой метод:{methodName} для нажатой кнопки.");
            }
        }

        public void StartWindowRun()
        {
            startForm.Show();
        }

        public void MainWindowRun()
        {
            try
            {
                render = new MenuRender(userChecker.MenuFile);
                render.ClickMenuItem += Render_ClickMenuItem;
                CreateMenu();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                mainForm.ShowMessage(ex.Message);
                startForm.Close();
            }
        }

        public void CreateMenu()
        {
            mainForm.RenderingMenu(render.menu);
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
            }
        }

        public void Departs() => mainForm.ShowMessage("Departs logic");
        public void Manual() => mainForm.ShowMessage("Manual logic");
        public void Docs() => mainForm.ShowMessage("Docs logic");
        public void Towns() => mainForm.ShowMessage("Towns logic");
        public void Window() => mainForm.ShowMessage("Window logic");
        public void Content() => mainForm.ShowMessage("Content logic");
        public void Others() => mainForm.ShowMessage("Others logic");
        public void MethodDoesNotExitst(string message) => mainForm.ShowMessage(message);

        private readonly IViewLoginForm startForm;
        private MainForm mainForm = new MainForm();
        private IUserChecker userChecker;
        private MenuRender render;
    }
}
