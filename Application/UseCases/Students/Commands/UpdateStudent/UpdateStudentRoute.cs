using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Students.Commands.UpdateStudent
{
    public class UpdateStudentRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
