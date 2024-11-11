namespace Employment_Verification_API.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public required string CompanyName { get; set; }
        public required string VerificationCode { get; set; }
    }

}
