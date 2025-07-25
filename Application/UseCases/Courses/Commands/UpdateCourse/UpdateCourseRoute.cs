using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Courses.Commands.UpdateCourse
{
    public class UpdateCourseRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
