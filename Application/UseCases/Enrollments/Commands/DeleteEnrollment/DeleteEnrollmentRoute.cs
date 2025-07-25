using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
