namespace AppraisalTool.App.Models
{
    public class JobProfilesViewmodel
    {

        public string PrimaryRole { get; set; }
        public string SecondaryRole { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
