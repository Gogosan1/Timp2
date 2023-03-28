using System;

namespace SecondLab
{
    public interface IViewLoginForm : IView
    {
        string UserLogin { get; }
        string Password { get; }
        event Action Login;
        void ShowError(string message);
    }
}
