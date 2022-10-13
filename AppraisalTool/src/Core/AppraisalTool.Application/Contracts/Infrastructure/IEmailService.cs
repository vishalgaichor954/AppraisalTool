using AppraisalTool.Application.Models.Mail;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
