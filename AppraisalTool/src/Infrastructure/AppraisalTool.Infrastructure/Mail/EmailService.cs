using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }
        //private readonly ISendGridClient _sendGridClient;

        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger /*ISendGridClient sendGridClient*/)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
            //_sendGridClient = sendGridClient;
        }

        public async Task<bool> SendEmail(Email email)
        {
            //    var subject = email.Subject;
            //    var to = new EmailAddress(email.To);
            //    var emailBody = email.Body;

            //    var from = new EmailAddress
            //    {
            //        Email = _emailSettings.FromAddress,
            //        Name = _emailSettings.FromName
            //    };

            //    var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            //    var response = await _sendGridClient.SendEmailAsync(sendGridMessage);

            //    _logger.LogInformation("Email sent");

            //    if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            //        return true;

            //    _logger.LogError("Email sending failed");

            //    return false;
            //}

            using (MailMessage mm = new MailMessage(_emailSettings.Mail, email.To))
            {
                mm.Subject = email.Subject;
                //string body = "Dear User" + ",";
                //body += "<br /> You application registered successfully on portal.";
                //body += "<br /><br /> we will contact you soon!.";
                //body += "<br /><br />Thanks" + ",";
                //body += "<br />Team support";
                mm.Body = email.Body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _emailSettings.Host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = _emailSettings.Port;
                smtp.Send(mm);
                _logger.LogInformation("Email Sent");
                return true;
            }
        }
    }
}
