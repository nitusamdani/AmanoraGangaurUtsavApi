
using System.ComponentModel.DataAnnotations;

namespace AmanoraGangaurUtsav.ViewModels
{
    
    public class UserRoleCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class UserRoleEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
