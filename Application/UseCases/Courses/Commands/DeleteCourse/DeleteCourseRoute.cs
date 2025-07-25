using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Courses.Commands.DeleteCourse
{
    public class DeleteCourseRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
