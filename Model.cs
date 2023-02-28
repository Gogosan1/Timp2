using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SecondLab
{
    public class Model
    {
        // Сделать де хэширование паролей
        // Декомпозировать юзеров?
        public bool IsUserExist(string login, string password)
        {
            bool CorrectUserInput = false;
            StreamReader reader = new StreamReader(possibleUsersFile);
            while(!reader.EndOfStream)
            {
                string s = reader.ReadLine();
               List<string> sList = s.Split(' ').ToList();
                
                if (sList[0] == login && sList[1] == password)
                {
                    MenuFile = sList[2];
                    CorrectUserInput = true;
                    break;
                }
            }
            reader.Close();
            if (CorrectUserInput == false)
                throw new Exception("Не верный логин или пароль");
            
            ShowMainForm.Invoke();
            
            return CorrectUserInput;
        }

        private string possibleUsersFile = "possibleUsersFile.txt";
        public string MenuFile { get; private set; }
        public event Action ShowMainForm;
    }
}
