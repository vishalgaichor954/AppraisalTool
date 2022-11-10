using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.Menu
{
    public class MenuModel
    {

        public int Menu_Id { get; set; }

        [Required(ErrorMessage = "Menu name is required")]
        public string MenuText { get; set; }

        [Required(ErrorMessage = "Class name is required")]
        public string MenuClass { get; set; }

        [Required(ErrorMessage = "Icon name is required")]
        public string MenuIcon { get; set; }

        [Required(ErrorMessage = "Flag name is required")]
        public string? MenuFlag { get; set; }

        [Required(ErrorMessage = "Controller name is required")]
        public string? MenuController { get; set; }

        [Required(ErrorMessage = "Action name is required")]
        public string? MenuAction { get; set; }

        [Required(ErrorMessage = "Link name is required")]
        public string? MenuLink { get; set; }
        public int? AddedBy { get; set; }

        public int? DeletedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Required(ErrorMessage = "Please Select role")]
        public List<int> RoleList { get; set; }
    }
}
