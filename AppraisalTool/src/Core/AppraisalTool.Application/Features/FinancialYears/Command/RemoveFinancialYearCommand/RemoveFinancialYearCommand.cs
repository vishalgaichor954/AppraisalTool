using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand
{
    public class RemoveFinancialYearCommand:IRequest<Response<RemoveFinancialYearCommandDto>>
    {
        public RemoveFinancialYearCommand()
        {
            
        }
        public RemoveFinancialYearCommand(int id)
        {
            Id=id;
        }
        public int Id { get; set; }
    }
}
