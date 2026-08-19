using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceTracker.Repository.Utility
{
    /// <summary>
    /// A custom JSON converter for serializing and deserializing <see cref="DateOnly"/> values
    /// in the format <c>YYYY-MM-dd</c>.
    /// </summary>
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        /// <summary>
        /// Reads and converts the JSON string representation of a date into a <see cref="DateOnly"/> object.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The type to convert to Date only.</param>
        /// <param name="options">The serialization options to use.</param>
        /// <returns>
        /// A <see cref="DateOnly"/> instance parsed from the JSON string.
        /// </returns>
        /// <exception cref="JsonException">
        /// Thrown when the JSON token is null or cannot be parsed into a valid <see cref="DateOnly"/>.
        /// </exception>
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? date = reader.GetString();
            if (date == null)
            {
                throw new JsonException("Date value is missing or null.");
            }

            return DateOnly.Parse(date);
        }

        /// <summary>
        /// Writes a <see cref="DateOnly"/> value as a JSON string in the format <c>YYYY-MM-dd</c>.
        /// </summary>
        /// <param name="writer">The Utf8 json writer to write to.</param>
        /// <param name="value">The date only value to write.</param>
        /// <param name="options">The serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}