using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_rest_logistics.Validation
{
    public class NumeroFlotaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

           

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;

            //var primeraLetra = value.ToString()[0].ToString();
            //var primerBloque = value.ToString().Remove(0, 5);
            //foreach (char c in primerBloque)
            //{
            //    if (!(c >= 'A' && c <= 'Z') &&
            //            !(c >= 'a' && c <= 'z')) 
            //            //&& 
            //            //!(c >= '0' && c <= '9'))
            //    {
            //        return new ValidationResult("La primeras 3 letras");
            //    }
            //}


            //if (primeraLetra != primeraLetra.ToUpper())
            //{
            //    return new ValidationResult("La primera letra debe ser mayúscula");
            //}

            return ValidationResult.Success;
        }
    }
}