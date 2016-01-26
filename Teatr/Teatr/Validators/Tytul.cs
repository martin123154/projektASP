using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teatr.Validators
{
    public class Tytul : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string tytul;

            if (value is string)
            {
                tytul = value.ToString();
            }
            else return new ValidationResult("Te pole nie powinno być puste");

            if (tytul.Length == 0)
                return new ValidationResult("Te pole nie powinno być puste");
            else
                tytul = value.ToString();
            if (tytul.Length < 3 || tytul.Length > 40)
                return new ValidationResult("Te pole powinno zawierać między 3 a 40 znaków");
            else
                tytul = value.ToString();


            return ValidationResult.Success;
        }

    }
}