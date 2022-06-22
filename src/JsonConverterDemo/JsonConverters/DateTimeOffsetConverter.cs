using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonConverterDemo.JsonConverters
{
    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        const string FORMAT = "yyyy-MM-dd HH:mm:ss.fffzzz";

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.ParseExact(reader.GetString(), FORMAT, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(FORMAT));
        }
    }
}
