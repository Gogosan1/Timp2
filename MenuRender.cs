/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondLab
{
    public class MenuRender
    {
        private List<MenuItem> mainItems;
        private string[] Errors;

        private string[] SplitLine(string line, int lineNumber)
        {
            string[] split = line.Split(' ');
            if (split.Length == 3 || split.Length == 4)
                return split;
            throw new Exception($"Ошибка при считывании строки {lineNumber + 1}");
        }
        private bool IsSplitCorrect(string[] split)
        {
            if (split.Length == 3 || split.Length == 4)
                return true;
            else
                return false;
        }

        public MenuRender(string pathToMenuFile)
        {
            string[] lines = File.ReadAllLines(pathToMenuFile);
            Errors = new string[lines.Length];

            if (lines == null || lines.Length == 0)
                throw new ArgumentNullException(nameof(pathToMenuFile));

            int lineNumber = 0, counterOfLevelIerarchy = 0;
            string line = lines[lineNumber];
            string[] split;

            split = line.Split(' ');

            mainItems = new List<MenuItem>();
            var subListOfItems = mainItems;
            var lastReadItem = new MenuItem();

            while (lines.Length > lineNumber)
            {
                if (IsSplitCorrect(split))
                {
                    var titleStep = Int32.Parse(split[0]);

                    if (titleStep == counterOfLevelIerarchy)
                    {
                        subListOfItems.Add(CreateMenuItem(line, commands));
                        lastReadItem = subListOfItems[subListOfItems.Count - 1];
                    }
                    else if (titleStep == counterOfLevelIerarchy + 1)
                    {
                        counterOfLevelIerarchy++;
                        subListOfItems = new List<MenuItem>();
                        subListOfItems.Add(CreateMenuItem(line, commands));
                        lastReadItem.Items = subListOfItems;
                        lastReadItem = subListOfItems[subListOfItems.Count - 1];
                    }
                    else if (titleStep < counterOfLevelIerarchy && titleStep >= 0)
                    {
                        counterOfLevelIerarchy = titleStep;

                        subListOfItems = mainItems;
                        for (int i = 0; i < titleStep; i++)
                        {
                            if (subListOfItems is null) throw new Exception("пока что говно");
                            lastReadItem = subListOfItems[subListOfItems.Count - 1];
                            subListOfItems = subListOfItems[subListOfItems.Count - 1].Items as List<MenuItem>;
                        }

                        if (subListOfItems is null) throw new Exception("пока что говно");

                        subListOfItems.Add(CreateMenuItem(line, commands));
                    }
                    else
                    {
                        throw new Exception("пока что говно"); ;
                    }
                }

                lineNumber++;
                if (lines.Length > lineNumber)
                {
                    line = lines[lineNumber];
                    split = line.Split();
                }
            }
        }

        private static MenuItem CreateMenuItem(string line, Dictionary<string, ReactiveCommand<string, Unit>> commands)
        {
            var splitLine = line.Split();
            return new MenuItem
            {
                Header = splitLine[1],
                IsEnabled = splitLine[2] != "1",
                IsVisible = splitLine[2] != "2",
                CommandParameter = splitLine[1],
                Command = commands.ContainsKey(splitLine[3]) ? commands[splitLine[3]] : null,
            };
        }

    }
}
*/