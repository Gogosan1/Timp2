using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.contracts.Model_contracts
{
    public interface IUserChecker
    {
        bool IsUserExist(string login, string password);
        string MenuFile { get; }
        event Action ShowMainForm;
    }
}
