using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand
{
    public class UpdateFinanacialYearCommand:IRequest<Response<UpdateFinancialYearCommandDto>>
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public bool IsActive { get; set; }

         public int? UpdatedBy { get; set; } 
    }
}
