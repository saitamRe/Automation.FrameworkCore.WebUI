using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.WebAbstractions.Pages
{
    public interface ILoginPage
    {
        void Login(string username, string password);
    }
}
