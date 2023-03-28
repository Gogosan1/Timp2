using System;
using System.Windows.Forms;

namespace SecondLab
{
    public interface IViewMainForm : IView
    {
        void RenderingMenu(MenuStrip menud);
    }
}
