using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Abstractions.Model;

namespace Infrastructure.Abstractions
{
    public interface IEmailService
    {
        Task<EmailSendResult> SendEmailAsync(string to, string subject, string template, Dictionary<string, string> templateParameters = null, string from = null);
    }
}
