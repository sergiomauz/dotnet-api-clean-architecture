using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Courses.Queries.GetStudentsByCourseId
{
    public class GetStudentsByCourseIdRoute
    {
        [FromRoute(Name = "course_id")]
        public int? CourseId { get; set; }
    }
}
