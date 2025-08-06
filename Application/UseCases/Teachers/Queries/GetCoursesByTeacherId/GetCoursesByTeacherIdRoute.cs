using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Queries.GetCoursesByTeacherId
{
    public class GetCoursesByTeacherIdRoute
    {
        [FromRoute(Name = "teacher_id")]
        public int? TeacherId { get; set; }
    }
}
