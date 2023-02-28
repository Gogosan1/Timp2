using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SecondLab
{
    public partial class MainForm : Form, IViewMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void RenderingMenu(string menuFile)
        {
            List<string> lines = new List<string>();
            int counterOfLines = 0;
            var menuItems = new List<ToolStripMenuItem>();
            StreamReader streamReader = new StreamReader(menuFile);
            while (!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
                string[] parshItem = lines[counterOfLines].Split(' ');
                counterOfLines++;
                menuItems.Add(new ToolStripMenuItem(parshItem[1]));
            }


            for (int i = counterOfLines - 1; i >= 0; i--)
            {
                string[] parshItem1 = lines[i].Split(' ');
               
                for (int j = i-1; j >= 0; j--)
                {
                    string[] parshItem2 = lines[j].Split(' ');
                    if (Convert.ToInt32(parshItem1[0]) - 1 == Convert.ToInt32(parshItem2[0]))
                    {

                        menuItems[j].DropDownItems.Add(menuItems[i]);
                        break;
                    }
                            
                }
                
            }
            for (int i = 0; i < counterOfLines; i++)
            {
                string[] parshItem1 = lines[i].Split(' ');

                if (parshItem1[0] == "0")
                    menuStrip.Items.Add(menuItems[i]);
                
            }
        }
        public void ShowError(string message)
        {
        }
      
        public new void Show ()
        {
            this.ShowDialog();
        }
        public event Action SelectedMenuItem;
    }
}
