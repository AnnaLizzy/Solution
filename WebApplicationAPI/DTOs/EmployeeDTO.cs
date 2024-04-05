﻿namespace WebApplicationAPI.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string? EmployeeNo { get; set; }
        public string? Password { get; set; }
        public string? EmployeeName { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Company { get; set; }
       
    }
}
