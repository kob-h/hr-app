using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.Abstractions.Model;

namespace Infrastructure.Email
{
    public class FluentEmailManager : IEmailService
    {
        private readonly IFluentEmail _email;

        public FluentEmailManager(IFluentEmail email)
        {
            _email = email;
        }
        public async Task<EmailSendResult> SendEmailAsync(string to, string subject, string template, Dictionary<string, string> templateParameters = null, string from = null)
        {
            var mail = _email
                .To(to)
                .Subject(subject);

            if (!string.IsNullOrWhiteSpace(from))
            {
                mail = mail.SetFrom(from);
            }

            if (templateParameters != null && templateParameters.Count > 0)
            {
                //todo: check if possible to optimize using ForEach
                dynamic eo = templateParameters.Aggregate(new ExpandoObject() as IDictionary<string, Object>,
                    (a, p) => { a.Add(p.Key, p.Value); return a; });

                mail = mail.UsingTemplate(template, eo);
            }
            else
            {
                mail = mail.Body(template);
            }


            var sendResult = await mail
                .SendAsync();

            return new EmailSendResult()
            {
                IsSuccessful = sendResult.Successful,
                ErrorMessages = sendResult.ErrorMessages
            };

        }
        
    }
}
