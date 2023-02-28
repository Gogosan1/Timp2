using System;

namespace SecondLab
{
    public interface IViewMainForm : IView
    {
        void RenderingMenu(string menuName);
        event Action SelectedMenuItem;
        void ShowError(string message);
    }
}
