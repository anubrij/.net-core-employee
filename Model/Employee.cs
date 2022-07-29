using Employee_API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Employee_API.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [DateInPast("Date of birth can not be today or in future", false)]
        [MinAge(25, "Minimum age should be 25")]
        public DateTime DateOfBirth { get; set; }

        public string Designation { get; set; }

        [DateInPast("Date of joining can not be in futire", false)]
        public DateTime DateOfJoining { get; set; }

        public int CTC { get; set; }

        public int Age
        {
            get
            {
                return this.GetAge(this.DateOfBirth);
            }
        }

        private int GetAge(DateTime DateOfBirth)
        {
            int age = DateTime.Now.Subtract(DateOfBirth).Days;
            age /= 365;
            return age;
        }
    }
}
