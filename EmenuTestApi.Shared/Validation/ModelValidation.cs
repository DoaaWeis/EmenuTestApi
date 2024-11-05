using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmenuTestApi.Shared.Validation
{
    public static class ModelValidation
    {
        /// <summary>
        /// Checks if a string is null or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is null or empty, otherwise false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Checks if a string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is null, empty, or only whitespace, otherwise false.</returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Validates if all required fields in an object are non-null and non-empty.
        /// </summary>
        /// <param name="model">The object to check.</param>
        /// <param name="properties">A list of property names to validate.</param>
        /// <returns>True if all specified properties are non-null and non-empty, otherwise false.</returns>
        public static bool ValidateModel(this object model, params string[] properties)
        {
            foreach (var propertyName in properties)
            {
                var property = model.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    var value = property.GetValue(model)?.ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        return false; // If any property is null or empty, validation fails.
                    }
                }
            }
            return true; // All specified properties are valid.
        }
    }

}
