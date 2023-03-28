using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SecondLab
{
    public partial class MainForm : Form, IViewMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
     
        public void RenderingMenu(MenuStrip menu)
        {
            List<ToolStripItem> items = new List<ToolStripItem>();

            for (int i = 0; i < menu.Items.Count; i++)
            {
                items.Add(menu.Items[i]);
            }
            for (int i = 0; i < items.Count; i++)
            {
                mainMenu.Items.Add(items[i]);
            }
        }

        public new void Show ()
        {
            this.ShowDialog();
        }
        
        public void ShowMessage(string message) 
        {
            MessageBox.Show(message);
        }
    }
}
