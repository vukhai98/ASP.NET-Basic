using System;
using System.Collections.Generic;

#nullable disable

namespace TestNetCore.Models.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public int? SkillId { get; set; }
        public int? YearsExperience { get; set; }
    }
}
