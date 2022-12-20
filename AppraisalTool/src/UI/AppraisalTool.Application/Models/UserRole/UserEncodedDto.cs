namespace AppraisalTool.App.Models.UserRole
{
    public class UserEncodedDto
    {
        public string Id { get; set; }

        
        public string? Role { get; set; }

        public int? AddedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
