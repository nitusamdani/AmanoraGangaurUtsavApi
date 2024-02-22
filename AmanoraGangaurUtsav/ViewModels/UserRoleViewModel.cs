
using System.ComponentModel.DataAnnotations;

namespace AmanoraGangaurUtsav.ViewModels
{
    public class UserRoleViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    
}
