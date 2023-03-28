using System;

namespace SecondLab
{
    public interface IViewMainForm : IView
    {
        void RenderingMenu(string menuName);
      //  public delegate void Action(string message);
       // event Action SelectedMenuItem;
        void ShowError(string message);
    }
}
