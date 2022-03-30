using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var text = value as string;
            if (text == null)
            {
                return new ValidationResult(false, "Please enter text.");
            }
            if (text.Length < MinLength)
            {
                return new ValidationResult(false, $"Please enter {MinLength} or more characters.");
            }
            if(OnlyText && !Regex.IsMatch(text, "[A-Za-z]"))
            {
                return new ValidationResult(false, "Only Text is allowed.");
            }
            return new ValidationResult(true, null);
        }

        public int MinLength { get; set; }
        public bool OnlyText { get; set; }
    }
}
