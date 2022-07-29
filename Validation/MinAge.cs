using System.ComponentModel.DataAnnotations;
using System;
namespace Employee_API.Validation
{
    public class MinAge : ValidationAttribute
    {
        private readonly int _age;
        public MinAge(int age, string errorMessage) : base(errorMessage)
        {
            _age = age;
        }
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return DateTime.Now.AddYears(-dateTime.Year).Year >= _age;
        }
    }
}
