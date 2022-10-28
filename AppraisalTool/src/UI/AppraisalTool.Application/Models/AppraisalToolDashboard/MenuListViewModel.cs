namespace AppraisalTool.App.Models.AppraisalToolDashboard
{
    public class MenuListViewModel
    {
        public int MenuRoleMapping_id { get; set; }
        public int Menu_id { get; set; }
        public int Role_id { get; set; }
        public UserRoleViewModel UserRole { get; set; }
        public MenuListVM MenuList { get; set; }

    }
}
