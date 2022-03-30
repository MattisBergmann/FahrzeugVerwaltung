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
    /// <summary>
    /// Validation Rule used for the <see cref="VehicleEditWindow"/>
    /// </summary>
    public class VehicleValidationRule : ValidationRule
    {
        /// <summary>
        /// Validate if <paramref name="value"/> fits the settings
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string text)
            {
                return new ValidationResult(false, "Please enter text.");
            }
            if (text.Length < MinLength)
            {
                return new ValidationResult(false, $"Please enter {MinLength} or more characters.");
            }
            if(OnlyText && !Regex.IsMatch(text, "[A-Za-z ]"))
            {
                return new ValidationResult(false, "Only Text is allowed.");
            }
            return new ValidationResult(true, null);
        }

        /// <summary>
        /// Gets or sets the minimal allowed length
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// Allow only text
        /// </summary>
        public bool OnlyText { get; set; }
    }
}
