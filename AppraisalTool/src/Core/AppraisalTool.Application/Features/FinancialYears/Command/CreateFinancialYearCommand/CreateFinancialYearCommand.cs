using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand
{
    public class CreateFinancialYearCommand:IRequest<Response<CreateFinancialYearDto>>
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set;  }

        public bool IsActive { get; set; } = false;
        public int? AddedBy { get; set; }
        
       
        public int? DeletedBy { get; set; }
        public int? UpdatedBy { get; set; }
        

       

    }
}
