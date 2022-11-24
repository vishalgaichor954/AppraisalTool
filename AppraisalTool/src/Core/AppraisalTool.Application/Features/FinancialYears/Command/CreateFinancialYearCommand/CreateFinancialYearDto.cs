using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand
{
    public class CreateFinancialYearDto
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }


    }
}
