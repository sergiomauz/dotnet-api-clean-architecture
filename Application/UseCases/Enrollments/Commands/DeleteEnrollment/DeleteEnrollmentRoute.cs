using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Enrollments.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
