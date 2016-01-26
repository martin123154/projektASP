using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teatr.Validators
{
    public class Wielkosc : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string wielkosc;
          

            if (value is string)
            {
                wielkosc = value.ToString();
            }
            else return new ValidationResult("Te pole nie powinno być puste");

            if (wielkosc.Length == 0)
                return new ValidationResult("Te pole nie powinno być puste");
            else
                wielkosc = value.ToString();

            if (wielkosc.Length < 3 || wielkosc.Length > 40)
                return new ValidationResult("Te pole powinno zawierać między 3 a 40 znaków");
            else
                wielkosc = value.ToString();


            return ValidationResult.Success;
        }

    }
}