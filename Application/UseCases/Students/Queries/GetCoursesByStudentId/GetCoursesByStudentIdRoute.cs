using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Students.Queries.GetCoursesByStudentId
{
    public class GetCoursesByStudentIdRoute
    {
        [FromRoute(Name = "student_id")]
        public int? StudentId { get; set; }
    }
}
