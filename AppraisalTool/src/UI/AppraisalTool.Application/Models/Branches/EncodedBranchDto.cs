namespace AppraisalTool.App.Models.Branches
{
    public class EncodedBranchDto
    {
        public string Id { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public int? AddedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
