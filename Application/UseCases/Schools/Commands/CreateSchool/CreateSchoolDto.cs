using System.Text.Json.Serialization;


namespace Application.UseCases.Schools.Commands.CreateSchool
{
    public class CreateSchoolDto
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
