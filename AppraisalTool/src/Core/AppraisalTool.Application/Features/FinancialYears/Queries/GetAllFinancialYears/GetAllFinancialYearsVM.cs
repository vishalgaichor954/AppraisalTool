using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears
{
    public class GetAllFinancialYearsVM
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}
