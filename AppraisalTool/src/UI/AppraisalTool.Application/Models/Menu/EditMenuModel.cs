namespace AppraisalTool.App.Models.Menu
{
    public class EditMenuModel
    {

        public int Menu_Id { get; set; }
        public string MenuText { get; set; }

        public string MenuClass { get; set; }
        public string MenuIcon { get; set; }

        public string? MenuFlag { get; set; }
        public string? MenuController { get; set; }

        public string? MenuAction { get; set; }

        public string? MenuLink { get; set; }

       

        public List<int> RoleList { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
