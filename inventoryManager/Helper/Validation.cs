using System.Text.RegularExpressions;

namespace InventoryManager.Helper
{
    /// <summary>
    /// Validation class which has validation methods.
    /// </summary>
    internal static class Validation
    {
        /// <summary>
        /// to check the input is null or not
        /// </summary>
        /// <param name="input"> the string to be checked </param>
        /// <returns> validation </returns>
        public static bool IsValidInput(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
