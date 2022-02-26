namespace StudentRecordManagementApp.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? City { get; set; }
        public DateTime CreateOn { get; set; }
        public string? Response { get; set; }
    }
}
