using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Queries.GetStudentsByTeacherId
{
    public class GetStudentsByTeacherIdRoute
    {
        [FromRoute(Name = "teacher_id")]
        public string? TeacherId { get; set; }
    }
}
