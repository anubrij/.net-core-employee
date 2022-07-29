using System.ComponentModel.DataAnnotations;
using System;
namespace Employee_API.Validation
{
    public class DateInPast : ValidationAttribute
    {
        private readonly bool _considerToday;
        public DateInPast(string errorMessage, bool considerToday = false): base(errorMessage)
        {
            _considerToday = considerToday;
        }
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if(!_considerToday)
            {
                return dateTime.Date < DateTime.Now.Date;
            }
            return dateTime.Date <= DateTime.Now.Date;
        }
    }
}
