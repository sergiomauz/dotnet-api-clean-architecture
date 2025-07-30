using System.Text.Json.Serialization;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentDto
    {
        [JsonPropertyName("course_id")]
        public string? CourseId { get; set; }

        [JsonPropertyName("student_id")]
        public string? StudentId { get; set; }
    }
}
