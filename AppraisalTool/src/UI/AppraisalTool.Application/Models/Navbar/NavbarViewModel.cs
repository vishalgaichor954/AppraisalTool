namespace AppraisalTool.App.Models.Navbar
{
    public class NavbarViewModel
    {
        public string ?UserName { get; set; }
        public string ?UserRole { get; set; }

        public int? UserId { get; set; }
        public dynamic ?SideBarList { get; set; }    
    }
}
