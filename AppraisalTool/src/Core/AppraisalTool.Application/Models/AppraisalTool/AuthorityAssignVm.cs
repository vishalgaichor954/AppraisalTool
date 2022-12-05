using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Models.AppraisalTool
{
    public class AuthorityAssignVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string RevaName { get; set; }

        public string RepaName { get; set; }

        public int RepaId { get; set; }
        public int RevaId { get; set; }

        public string Name { get; set; }
    }
}
