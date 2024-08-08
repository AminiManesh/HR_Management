namespace HR_Management.MVC.Models.LeaveType
{
    public class LeaveTypeVM : ILeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
