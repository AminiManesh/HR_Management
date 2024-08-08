using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Models.LeaveType
{
    public class UpdateLeaveTypeVM : ILeaveTypeVM
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Default Number Of Days")]
        public int DefaultDay { get; set; }
    }
}
