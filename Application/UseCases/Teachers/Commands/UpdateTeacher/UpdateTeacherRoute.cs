using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
