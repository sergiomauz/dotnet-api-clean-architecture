using System.Text.Json.Serialization;


namespace Application.UseCases.Enrollments.Commands.CreateEnrollment
{
    public class CreateEnrollmentDto
    {
        [JsonPropertyName("study_group_id")]
        public int? StudyGroupId { get; set; }

        [JsonPropertyName("student_id")]
        public int? StudentId { get; set; }
    }
}
