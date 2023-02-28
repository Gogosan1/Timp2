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
            StreamReader streamReader = new StreamReader(menuFile);
            while (!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
                counterOfLines++;
            }

            List<string> linesInner = new List<string>();
            //ToolStripMenuItem fileItem = new ToolStripMenuItem("1");
           ToolStripMenuItem fileItem1 = new ToolStripMenuItem("12");
           ToolStripMenuItem fileItem3 = new ToolStripMenuItem("123");
           // ToolStripMenuItem fileItem4 = new ToolStripMenuItem("1234");
            //fileItem.DropDownItems.Add(fileItem1);
           // fileItem1.DropDownItems.Add(fileItem3);
           // fileItem3.DropDownItems.Add(fileItem4);
           // menuStrip.Items.Add(fileItem);
            for (int i = 0; i < counterOfLines; i++)
            {
                string[] mass = lines[i].Split(' ');
                ToolStripMenuItem fileItem = new ToolStripMenuItem(mass[1]);
                linesInner.Add(lines[i]);
                if (mass[0] == "0")
                {
                    if (linesInner.Count > 1)
                    {
                        var menu = new List<ToolStripMenuItem>();
                        linesInner.Remove(lines[i]);
                        for (int f = 0; f < linesInner.Count; f++)
                        {
                            string[] mass0 = linesInner[f].Split(' ');
                            menu.Add(new ToolStripMenuItem(mass[1]));
                        }
                        for (int j = 1; j < linesInner.Count; j++)
                        {
                            string[] mass0 = linesInner[0].Split(' ');
                            string[] mass1 = linesInner[j].Split(' ');
                            string[] massLast = linesInner[j-1].Split(' ');

                            var fileItem2 = new ToolStripMenuItem(mass1[1]);
                            var fileItemLast = new ToolStripMenuItem(massLast[1]);
                            
                            if (mass0[0] == "0")
                            {
                                fileItem1 = new ToolStripMenuItem(mass0[1]);
                                fileItem3 = fileItem1;
                            }
                            if ( Convert.ToInt32(mass0[0]) + 1 == Convert.ToInt32(mass1[0]))
                            {
                               
                                fileItem3.DropDownItems.Add(fileItem2);
                            }
                            else
                            {
                                mass0 = lines[j-1].Split(' ');
                                fileItem3 = fileItemLast;
                            }
                            if (j + 1 == linesInner.Count)
                                menuStrip.Items.Add(fileItem1);
                        }
                        linesInner.Clear();
                        linesInner.Add(lines[i]);
                    }
                    //fileItem1 = new ToolStripMenuItem(mass[1]);
                    if (mass.Length != 3 && linesInner.Count == 1)
                    {
                       menuStrip.Items.Add(fileItem);
                        linesInner.Clear();
                    }
                }
            }
            /*for ( int i = 0; i < counterOfLines; i++)
            {
                string[] mass = lines[i].Split(' ');

                ToolStripMenuItem fileItem2 = new ToolStripMenuItem(mass[1]);
                //  if (mass.Length == 3)
                //   linesInner.Add(lines[i]);
                if (i == 1 || i == 2)
                fileItem.DropDownItems.Add(fileItem2);

                
            */   /* if (mass[0] != "0")
                    linesInner.Add(lines[i]);
                else
                {
                    menuStrip.Items.Add(fileItem);
                    linesInner.Clear();
                }
               */




            /*if (mass.Length == 3)
            {
                int hirerachyLevel0 = Convert.ToInt32(mass[0]);
                string[] mass2 = lines[i+1].Split(' ');
                int hierarchyLevel1 = Convert.ToInt32(mass2[0]);
                do
                {
                    if (i + 1 == counterOfLines)
                        break;
                    i++;
                    mass2 = lines[i].Split(' ');
                    hierarchyLevel1 = Convert.ToInt32(mass2[0]);
                    if (hierarchyLevel1 == hirerachyLevel0)
                        break;
                    fileItem.DropDownItems.Add(new ToolStripMenuItem(mass2[1]));
                }
                while (hirerachyLevel0 != hierarchyLevel1);
            }*/

            // menuStrip.Items.Add(fileItem);

            //}

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
