﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationApp.Models
{
    public class Shift
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateTime DateWork { get; set; }
       
    }
}
