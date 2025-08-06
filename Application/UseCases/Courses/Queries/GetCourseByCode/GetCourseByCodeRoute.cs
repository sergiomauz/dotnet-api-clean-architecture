using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Courses.Queries.GetCourseByCode
{
    public class GetCourseByCodeRoute
    {
        [FromRoute(Name = "code")]
        public string? Code { get; set; }
    }
}
