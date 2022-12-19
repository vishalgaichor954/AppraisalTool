using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Models.Mail;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> Emailservice()
        {
            var email = new Email
            {
                To = "test",
                Subject = "test",
                Body = "test"
            };
            var mockemialRepo = new Mock<IEmailService>();
            mockemialRepo.Setup(repo => repo.SendEmail(email)).ReturnsAsync(true);
            return mockemialRepo;
        }
    }
}
