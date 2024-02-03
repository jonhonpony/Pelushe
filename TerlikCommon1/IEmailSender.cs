using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerlikCommon
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string name, string email, string subject, string body);

    }
}
