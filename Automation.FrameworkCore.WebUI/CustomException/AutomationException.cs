using Automation.Framework.Core.WebUI.CustomException;


namespace Automation.FrameworkCore.WebUI.CustomException
{
    public class AutomationException : Exception
    {
        public AutomationException(string message) : base(message) { }
        public AutomationException(ErrorItems errorItems) : base($"{errorItems}") { }
        public AutomationException(ErrorItems errorItems, string message) :base($"{errorItems} : {message}") { }
        
        
    }
}
