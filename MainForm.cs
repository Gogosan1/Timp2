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

        private bool IsLineCorrect(string line)
        {
            if (line != null && (line.Split(' ').Length == 3 || line.Split(' ').Length == 4)) 
                return true;
            else
                return false;
        }


        public void RenderingMenu(string menuFile)
        {
            menu.Items.Clear();
            
            List<string> lines = new List<string>();
            int counterOfLines = 0;
            var menuItems = new List<ToolStripMenuItem>();
            StreamReader streamReader = new StreamReader(menuFile);

            // создание всех элементов меню
            while (!streamReader.EndOfStream)
            {
                // проверить что строка считалась корректно IsLineCorrect(line);

                lines.Add(streamReader.ReadLine());
                string[] parshItem = lines[counterOfLines].Split(' ');
                counterOfLines++;

                var menuItem = new ToolStripMenuItem();
                menuItem.Text = parshItem[1];

                switch (Convert.ToInt32(parshItem[2]))
                {
                    case 1:
                        menuItem.Enabled = false;
                        break;
                    case 2:
                        menuItem.Enabled = false;
                        menuItem.Visible = false;
                        break;
                    default:
                        menuItem.Enabled = true;
                        break;
                }
                menuItems.Add(menuItem);
            }

            
            // добавление всех элементов меню в само меню
            for (int i = counterOfLines - 1; i >= 0; i--)
            {
                string[] parshItem1 = lines[i].Split(' ');
               
                for (int j = i-1; j >= 0; j--)
                {
                    string[] parshItem2 = lines[j].Split(' ');
                    if (Convert.ToInt32(parshItem1[0]) - 1 == Convert.ToInt32(parshItem2[0]))
                    {
                        menuItems[j].DropDownItems.Insert(0,menuItems[i]);
                        break;
                    }
                            
                }
                
            }


            for (int i = 0; i < counterOfLines; i++)
            {
                string[] parshItem1 = lines[i].Split(' ');

                if (parshItem1[0] == "0")
                    menu.Items.Add(menuItems[i]);
                
            }







        }















        public void ShowError(string message)
        {
        }
      
        public new void Show ()
        {
            this.ShowDialog();
        }
        public delegate void Action(string message);
        public event Action SelectedMenuItem;

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectedMenuItem?.Invoke("Something");
        }
    }
}
