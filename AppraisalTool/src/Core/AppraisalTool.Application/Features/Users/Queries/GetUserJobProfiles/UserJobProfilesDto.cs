using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Queries.GetUserJobProfiles
{
    public class UserJobProfilesDto
    {
        public string PrimaryRole { get; set; }
        public string SecondaryRole { get; set; }
        public List<string> Roles { get; set; }
    }
}
