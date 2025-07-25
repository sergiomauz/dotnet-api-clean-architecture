using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Students.Commands.DeleteStudent
{
    public class DeleteStudentRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
