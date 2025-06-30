using System.Text.Json.Serialization;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentDto
    {
        [JsonPropertyName("school_id")]
        public int? SchoolId { get; set; }

        [JsonPropertyName("student_id")]
        public int? StudentId { get; set; }
    }
}
