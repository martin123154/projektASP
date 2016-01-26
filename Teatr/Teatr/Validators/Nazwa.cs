using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teatr.Validators
{
    public class Nazwa : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string nazwa;
            
            if (value is string)
            {
                nazwa = value.ToString();
            }
            else return new ValidationResult("Te pole nie powinno być puste");

            if (nazwa.Length == 0)
                return new ValidationResult("Te pole nie powinno być puste");


            if (nazwa.Length < 3 || nazwa.Length > 40)
                return new ValidationResult("Te pole powinno zawierać między 3 a 40 znaków");



            return ValidationResult.Success;
        }

    }
}