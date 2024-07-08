using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.WebAbstractions.ISteps
{
    public interface ILoginSteps
    {
        void GivenLoginWithValidCredentials();
        void GivenLoginWithInvalidCredentials();
    }
}
