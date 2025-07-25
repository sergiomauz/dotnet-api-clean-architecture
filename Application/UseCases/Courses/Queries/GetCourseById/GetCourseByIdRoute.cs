using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Courses.Queries.GetCourseById
{
    public class GetCourseByIdRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
