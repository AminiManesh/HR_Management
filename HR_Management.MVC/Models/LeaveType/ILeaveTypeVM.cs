using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HR_Management.MVC.Models.LeaveType
{
    public interface ILeaveTypeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Default Number Of Days")]
        public int DefaultDay { get; set; }
    }
}
