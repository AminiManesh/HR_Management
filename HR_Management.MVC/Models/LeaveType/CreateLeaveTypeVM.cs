using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models.LeaveType
{
    public class CreateLeaveTypeVM : ILeaveTypeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Default Number Of Days")]
        public int DefaultDay { get; set; }
    }
}
