using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.App.Models.Branches
{
    public class BranchVm
    {
        public int Id { get; set; }
        //BranchCodeExists
        [Remote("BranchCodeExists", "Branch", HttpMethod = "GET", ErrorMessage = "Branch with this code exists")]

        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public int? AddedBy { get; set; }

        public int ? UpdatedBy { get; set; }



    }
}
