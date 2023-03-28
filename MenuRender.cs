using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System;

namespace SecondLab 
{ 
    public class MenuRender
    { 
        public MenuStrip menu { get; private set; }
        public event Action<string> ClickMenuItem;

        public MenuRender(string menuFile) 
        { 
            menu = new MenuStrip();
            menu.Items.Clear();

            List<string> lines = new List<string>();
            int counterOfLines = 0;
            var menuItems = new List<ToolStripMenuItem>();
            StreamReader streamReader = new StreamReader(menuFile);

            // создание всех элементов меню
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (!IsLineCorrect(line))
                {
                    throw new Exception($"Файл: {menuFile} содержит строку не верного формата.\n" +
                        $"Этa строка находиться под номером {counterOfLines}.");
                }
                lines.Add(line);
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
                // добавление обработчиков
                if (parshItem.Length > 3)
                {
                    menuItem.Click += (s, e) => ClickMenuItem.Invoke(parshItem[3]);
                }
             

                menuItems.Add(menuItem);
            }

            // добавление всех элементов низшего ранга по уровню иерархии
            for (int i = counterOfLines - 1; i >= 0; i--)
            {
                string[] parshItem1 = lines[i].Split(' ');

                for (int j = i - 1; j >= 0; j--)
                {
                    string[] parshItem2 = lines[j].Split(' ');
                    if (Convert.ToInt32(parshItem1[0]) - 1 == Convert.ToInt32(parshItem2[0]))
                    {
                        menuItems[j].DropDownItems.Insert(0, menuItems[i]);
                        break;
                    }

                }

            }

            // Добавление всех элементов меню в само меню
            for (int i = 0; i < counterOfLines; i++)
            {
                string[] parshItem1 = lines[i].Split(' ');

                if (parshItem1[0] == "0")
                    menu.Items.Add(menuItems[i]);

            }
        }

        private bool IsLineCorrect(string line)
        {
            if (line != null && (line.Split(' ').Length == 3 || line.Split(' ').Length == 4))
                return true;
            else
                return false;
        }


    }

}